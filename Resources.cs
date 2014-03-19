﻿using System;
using System.IO;
using System.Collections.Generic;
using OpenTK.Audio.OpenAL;
using System.Threading;
using System.Reflection;

namespace HatlessEngine
{
    /// <summary>
    /// Will contain all references to the resource files.
    /// Keeps resources loaded until they are no longer needed, or aren't used for a while.
    /// </summary>
    public static class Resources
    {
		/// <summary>
		/// If set this (optionally relative) will be checked before the program's location will be checked.
		/// </summary>
		public static string RootDirectory = "";

		/// <summary>
		/// If resource execution (like Music.Play or Sprite.Draw) is requested when the resource is not loaded, instead of throwing an exception load it at that point.
		/// NOT A GREAT PRACTICE, use this only in very specific situations, if loading fails at this point it will strill try to execute regardless.
		/// </summary>
		public static bool JustInTimeLoading = false;

        //resources
		public static List<View> Views = new List<View>();
		public static Dictionary<string, Sprite> Sprites = new Dictionary<string, Sprite>();
        public static Dictionary<string, Font> Fonts = new Dictionary<string, Font>();
		public static Dictionary<string, Music> Music = new Dictionary<string, Music>();
		public static Dictionary<string, Sound> Sounds = new Dictionary<string, Sound>();

        //collections
		public static Dictionary<string, Objectmap> Objectmaps = new Dictionary<string, Objectmap>();
		public static Dictionary<string, Spritemap> Spritemaps = new Dictionary<string, Spritemap>();
        //public static Dictionary<string, CombinedMap> CombinedMaps = new Dictionary<string, CombinedMap>();

        //objects
		public static List<LogicalObject> Objects = new List<LogicalObject>();
		public static Dictionary<Type, List<PhysicalObject>> PhysicalObjectsByType = new Dictionary<Type, List<PhysicalObject>>();

		internal static List<int> AudioSources = new List<int>();
		internal static Dictionary<int, AudioControl> AudioControls = new Dictionary<int, AudioControl>();

        //addition/removal (has to be done after looping)
		internal static List<LogicalObject> AddObjects = new List<LogicalObject>();
		internal static List<LogicalObject> RemoveObjects = new List<LogicalObject>();

		internal static bool MusicStreamerActive = false;
		internal static Thread MusicStreamerThread;

		internal static List<WeakReference> ManagedSprites = new List<WeakReference>();

		/// <summary>
		/// Gets the FileStream of a (resource) file with the given filename.
		/// All resources are loaded this way.
		/// Priority: 
		/// 1: Embedded Resource in the entry assembly.
		/// 2: File in the RootDirectory.
		/// 3: File in the application's directory, or an absolute filepath.
		/// Returns null if not able to obtain a stream from all locations.
		/// Also, don't work with backslashes, they are nasty and unaccounted for.
		/// </summary>
		public static Stream GetStream(string fileName)
		{
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			Stream stream = entryAssembly.GetManifestResourceStream(entryAssembly.GetName().Name + "." + fileName.Replace('/', '.'));
			if (stream != null)
				return stream;

			if (RootDirectory != "" && File.Exists(RootDirectory + fileName))
			{
				stream = File.Open(RootDirectory + fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				if (stream != null)
					return stream;
			}

			if (File.Exists(fileName))
			{
				stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				if (stream != null)
					return stream;
			}

			return null;
		}

		public static View AddView(Rectangle area, Rectangle viewport)
        {
			View view = new View(area, viewport);
            Views.Add(view);
            return view;
        }
		public static Sprite AddSprite(string id, string filename, Point size)
        {
            Sprite sprite;
			if (size == new Point(0f, 0f))
				sprite = new Sprite(id, filename);
            else
                sprite = new Sprite(id, filename, size);

            Sprites.Add(id, sprite);

            return sprite;
        }
        public static Sprite AddSprite(string id, string filename)
        {
			return AddSprite(id, filename, new Point(0f, 0f));
		}
        public static Font AddFont(string id, string filename)
        {
			Font font = new Font(id, filename);
            Fonts.Add(id, font);
            return font;
        }
		public static Music AddMusic(string id, string filename)
        {
			Music music = new Music(id, filename);
            Music.Add(id, music);
            return music;
        }
        public static Sound AddSound(string id, string filename)
        {
			Sound sound = new Sound(id, filename);
            Sounds.Add(id, sound);
            return sound;
		}
        public static Objectmap AddObjectmap(string id, params ObjectBlueprint[] objectmapBlueprints)
        {
            Objectmap objectmap = new Objectmap(id, objectmapBlueprints);
            Objectmaps.Add(id, objectmap);
            return objectmap;
        }
		public static Spritemap AddSpritemap(string id, params ManagedSprite[] managedSprites)
        {
			Spritemap spritemap = new Spritemap(id, managedSprites);
            Spritemaps.Add(id, spritemap);
            return spritemap;
        }
		/// <summary>
		/// Add a spritemap from file (saved by Spritemap.WriteToFile)
		/// </summary>
        public static Spritemap AddSpritemap(string id, string filename)
		{
			Spritemap spritemap = new Spritemap(id, filename);
			Spritemaps.Add(id, spritemap);
			return spritemap;
		}

		public static void LoadAllExternalResources()
		{
			foreach(KeyValuePair<string, Sprite> pair in Sprites)
				pair.Value.Load();
			foreach(KeyValuePair<string, Font> pair in Fonts)
				pair.Value.Load();
			foreach(KeyValuePair<string, Sound> pair in Sounds)
				pair.Value.Load();
			foreach(KeyValuePair<string, Music> pair in Music)
				pair.Value.Load();
		}

		internal static void ObjectAdditionAndRemoval()
		{
			//object addition
			Objects.AddRange(AddObjects);
			AddObjects.Clear();

			//object removal
			foreach (LogicalObject logicalObject in RemoveObjects)
				Objects.Remove(logicalObject);
			RemoveObjects.Clear();
		}

		/// <summary>
		/// Gets an OpenAL source identifier.
		/// Source will be managed by HatlessEngine to prevent not playing of sound after all device channels are occupied.
		/// </summary>
		internal static int GetSource()
		{
			int source;
			//will execute multiple times if cleanup has not removed the source from AudioControls yet
			while (AudioControls.ContainsKey(source = AL.GenSource())) { }
			AudioSources.Add(source);
			return source;
		}

		/// <summary>
		/// Removes all stopped sources.
		/// </summary>
		internal static void SourceRemoval()
		{
			List<int> removeSources = new List<int>();
			foreach(int source in AudioSources)
			{
				if (AL.GetSourceState(source) == ALSourceState.Stopped)
				{
					AL.DeleteSource(source);
					removeSources.Add(source);
				}
			}

			foreach(int source in removeSources)
			{
				AudioSources.Remove(source);
				AudioControls[source].PerformStopped();
				AudioControls.Remove(source);
			}
		}

		internal static void LaunchMusicStreamerThread()
		{
			if (!Resources.MusicStreamerActive)
			{
				MusicStreamerThread = new Thread(new ThreadStart(Resources.MusicStreamer));
				MusicStreamerThread.Name = "HatlessEngine MusicStreamer";
				MusicStreamerThread.IsBackground = true;
				MusicStreamerThread.Start();
			}
		}

		internal static void MusicStreamer()
		{
			MusicStreamerActive = true;

			//decides whether the thread should stay alive
			bool workNeedsDoing = true;

			while (workNeedsDoing)
			{
				workNeedsDoing = false;

				//work when there's workin' to do
				foreach(KeyValuePair<string, Music> pair in Music)
				{
					Music music = pair.Value;

					if (music.Streaming)
					{
						workNeedsDoing = true;

						int buffersProcessed;
						AL.GetSource(music.SourceId, ALGetSourcei.BuffersProcessed, out buffersProcessed);

						if (music.JustStartedPlaying)
						{
							//will force filling the 2 still empty buffers and make sure the activebuffer is right afterwards
							buffersProcessed = 2;
							music.ActiveBufferId = 1;
							music.JustStartedPlaying = false;
						}

						//if the music's done with a buffer, fill it again and append it
						while (buffersProcessed > 0)
						{
							AL.SourceUnqueueBuffer(music.SourceId);

							//fill the just released buffer
							int requestedSamples = music.WaveReader.SampleRate / 2 * music.WaveReader.Channels;
							int readSamples;
							short[] waveData = music.WaveReader.ReadSamples(requestedSamples, out readSamples);
							AL.BufferData(music.BufferIds[music.ActiveBufferId], music.WaveReader.ALFormat, waveData, readSamples * 2, music.WaveReader.SampleRate);
					
							AL.SourceQueueBuffer(music.SourceId, music.BufferIds[music.ActiveBufferId]);

							if (++music.ActiveBufferId == 3)
								music.ActiveBufferId = 0;

							//perform MusicChanged event in old music when it actually switched over
							if (music.PerformMusicChangedEventDelay != 3)
							{
								music.PerformMusicChangedEventDelay--;
								if (music.PerformMusicChangedEventDelay == 0)
								{
									music.PerformMusicChangedEventMusic.PerformMusicChanged(music);
									music.PerformMusicChangedEventMusic = null;
									music.PerformMusicChangedEventDelay = 3;
								}
							}

							//this was the last buffer, take action
							if (readSamples != requestedSamples)
							{
								if (music.Loop)
								{
									music.WaveReader.Rewind(music.LoopStartSample);
								}
								else
								{
									music.Streaming = false; //reached end

									//tight looping by hijacking sound source for new music
									if (music.PlayAfterMusic != "")
									{
										Music newMusic = Resources.Music[music.PlayAfterMusic];
										newMusic.SourceId = music.SourceId;
										newMusic.WaveReader.Rewind();
										newMusic.Streaming = true;

										//for having the MusicChanged event trigger at a more accurate time (still not perfect, but meh)
										newMusic.PerformMusicChangedEventDelay = 2;
										newMusic.PerformMusicChangedEventMusic = music;
									}
								}
							}

							buffersProcessed--;
						}
					}
				}
				Thread.Sleep(200); //cya in a fifth of a second!
			}
			MusicStreamerActive = false;
		}

		internal static void UpdateManagedSprites()
		{
			List<WeakReference> removeManagedSprites = new List<WeakReference>();
			foreach(WeakReference managedSprite in ManagedSprites)
			{
				//check if alive and add to remove list if not
				if (managedSprite.IsAlive)
				{
					//perform step
					((ManagedSprite)managedSprite.Target).Step();
				}
				else
					removeManagedSprites.Add(managedSprite);
			}

			foreach(WeakReference managedSprite in removeManagedSprites)
			{
				ManagedSprites.Remove(managedSprite);
			}
		}
    }
}
