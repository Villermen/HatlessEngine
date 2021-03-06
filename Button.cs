﻿namespace HatlessEngine
{
	public enum Button
	{
		MouseLeft = 1001,
		MouseMiddle = 1002,
		MouseRight = 1003,
		MouseX1 = 1004,
		MouseX2 = 1005,
		MousewheelUp = 1006,
		MousewheelDown = 1007,
		MousewheelLeft = 1008,
		MousewheelRight = 1009,

		KeyboardUnknown = 2000, //SDL.SDL_charmapped
		KeyboardBackspace = 2008,
		KeyboardTab = 2009,
		KeyboardReturn = 2013,
		KeyboardEnter = KeyboardReturn,
		KeyboardEscape = 2027,
		KeyboardSpace = 2032,
		KeyboardExclamationPoint = 2033,
		KeyboardDoubleQuote = 2034,
		KeyboardHash = 2035,
		KeyboardDollar = 2036,
		KeyboardPercent = 2037,
		KeyboardAmpersand = 2038,
		KeyboardQuote = 2039,
		KeyboardParenthesisLeft = 2040,
		KeyboardParenthesisRight = 2041,
		KeyboardAsterisk = 2042,
		KeyboardPlus = 2043,
		KeyboardComma = 2044,
		KeyboardMinus = 2045,
		KeyboardPeriod = 2046,
		KeyboardSlash = 2047,
		Keyboard0 = 2048,
		Keyboard1 = 2049,
		Keyboard2 = 2050,
		Keyboard3 = 2051,
		Keyboard4 = 2052,
		Keyboard5 = 2053,
		Keyboard6 = 2054,
		Keyboard7 = 2055,
		Keyboard8 = 2056,
		Keyboard9 = 2057,
		KeyboardColon = 2058,
		KeyboardSemicolon = 2059,
		KeyboardLess = 2060,
		KeyboardEquals = 2061,
		KeyboardGreater = 2062,
		KeyboardQuestionMark = 2063,
		KeyboardAt = 2064,
		KeyboardBracketLeft = 2091,
		KeyboardBackslash = 2092,
		KeyboardBracketRight = 2093,
		KeyboardCaret = 2094,
		KeyboardUnderscore = 2095,
		KeyboardBackQuote = 2096,
		KeyboardA = 2097,
		KeyboardB = 2098,
		KeyboardC = 2099,
		KeyboardD = 2100,
		KeyboardE = 2101,
		KeyboardF = 2102,
		KeyboardG = 2103,
		KeyboardH = 2104,
		KeyboardI = 2105,
		KeyboardJ = 2106,
		KeyboardK = 2107,
		KeyboardL = 2108,
		KeyboardM = 2109,
		KeyboardN = 2110,
		KeyboardO = 2111,
		KeyboardP = 2112,
		KeyboardQ = 2113,
		KeyboardR = 2114,
		KeyboardS = 2115,
		KeyboardT = 2116,
		KeyboardU = 2117,
		KeyboardV = 2118,
		KeyboardW = 2119,
		KeyboardX = 2120,
		KeyboardY = 2121,
		KeyboardZ = 2122,
		KeyboardDelete = 2177,
		KeyboardCapslock = 2500, //SDL.SDL_scancodemapped
		KeyboardF1 = 2501,
		KeyboardF2 = 2502,
		KeyboardF3 = 2503,
		KeyboardF4 = 2504,
		KeyboardF5 = 2505,
		KeyboardF6 = 2506,
		KeyboardF7 = 2507,
		KeyboardF8 = 2508,
		KeyboardF9 = 2509,
		KeyboardF10 = 2510,
		KeyboardF11 = 2511,
		KeyboardF12 = 2512,
		KeyboardPrintScreen = 2513,
		KeyboardScrolllock = 2514,
		KeyboardPause = 2515,
		KeyboardInsert = 2516,
		KeyboardHome = 2517,
		KeyboardPageUp = 2518,
		KeyboardEnd = 2520,
		KeyboardPageDown = 2521,
		KeyboardRight = 2522,
		KeyboardLeft = 2523,
		KeyboardDown = 2524,
		KeyboardUp = 2525,
		KeyboardNumlock = 2526,
		KeyboardNumpadDivide = 2527,
		KeyboardNumpadMultiply = 2528,
		KeyboardNumpadMinus = 2529,
		KeyboardNumpadSubtract = KeyboardNumpadMinus,
		KeyboardNumpadPlus = 2530,
		KeyboardNumpadAdd = KeyboardNumpadPlus,
		KeyboardNumpadEnter = 2531,
		KeyboardNumpad1 = 2532,
		KeyboardNumpad2 = 2533,
		KeyboardNumpad3 = 2534,
		KeyboardNumpad4 = 2535,
		KeyboardNumpad5 = 2536,
		KeyboardNumpad6 = 2537,
		KeyboardNumpad7 = 2538,
		KeyboardNumpad8 = 2539,
		KeyboardNumpad9 = 2540,
		KeyboardNumpad0 = 2541,
		KeyboardNumpadPeriod = 2542,
		KeyboardApplication = 2544,
		KeyboardPower = 2545,
		KeyboardNumpadEquals = 2546,
		KeyboardF13 = 2547,
		KeyboardF14 = 2548,
		KeyboardF15 = 2549,
		KeyboardF16 = 2550,
		KeyboardF17 = 2551,
		KeyboardF18 = 2552,
		KeyboardF19 = 2553,
		KeyboardF20 = 2554,
		KeyboardF21 = 2555,
		KeyboardF22 = 2556,
		KeyboardF23 = 2557,
		KeyboardF24 = 2558,
		KeyboardExecute = 2559,
		KeyboardHelp = 2560,
		KeyboardMenu = 2561,
		KeyboardSelect = 2562,
		KeyboardStop = 2563,
		KeyboardAgain = 2564,
		KeyboardUndo = 2565,
		KeyboardCut = 2566,
		KeyboardCopy = 2567,
		KeyboardPaste = 2568,
		KeyboardFind = 2569,
		KeyboardMute = 2570,
		KeyboardVolumeUp = 2571,
		KeyboardVolumeDown = 2572,
		KeyboardNumpadComma = 2576,
		KeyboardNumpadEqualsAS400 = 2577,
		KeyboardAltErase = 2596,
		KeyboardSysReq = 2597,
		KeyboardCancel = 2598,
		KeyboardClear = 2599,
		KeyboardPrior = 2600,
		KeyboardReturn2 = 2601,
		KeyboardSeparator = 2602,
		KeyboardOut = 2603,
		KeyboardOpEr = 2604,
		KeyboardClearAgain = 2605,
		KeyboardCrSel = 2606,
		KeyboardExSel = 2607,
		KeyboardNumpad00 = 2619,
		KeyboardNumpad000 = 2620,
		KeyboardThousandsSeparator = 2621,
		KeyboardDecimalSeparator = 2622,
		KeyboardCurrencyUnit = 2623,
		KeyboardCurrencySubUnit = 2624,
		KeyboardNumpadParenthesisLeft = 2625,
		KeyboardNumpadParenthesisRight = 2626,
		KeyboardNumpadBraceLeft = 2627,
		KeyboardNumpadBraceRight = 2628,
		KeyboardNumpadTab = 2629,
		KeyboardNumpadBackspace = 2630,
		KeyboardNumpadA = 2631,
		KeyboardNumpadB = 2632,
		KeyboardNumpadC = 2633,
		KeyboardNumpadD = 2634,
		KeyboardNumpadE = 2635,
		KeyboardNumpadF = 2636,
		KeyboardNumpadXOR = 2637,
		KeyboardNumpadPower = 2638,
		KeyboardNumpadPercent = 2639,
		KeyboardNumpadLess = 2640,
		KeyboardNumpadGreater = 2641,
		KeyboardNumpadAmpersand = 2642,
		KeyboardNumpadDoubleAmpersand = 2643,
		KeyboardNumpadVerticalBar = 2644,
		KeyboardNumpadDoubleVerticalBar = 2645,
		KeyboardNumpadColon = 2646,
		KeyboardNumpadHash = 2647,
		KeyboardNumpadSpace = 2648,
		KeyboardNumpadAt = 2649,
		KeyboardNumpadExclamationPoint = 2650,
		KeyboardNumpadMemStore = 2651,
		KeyboardNumpadMemRecall = 2652,
		KeyboardNumpadMemClear = 2653,
		KeyboardNumpadMemAdd = 2654,
		KeyboardNumpadMemSubtract = 2655,
		KeyboardNumpadMemMultiply = 2656,
		KeyboardNumpadMemDivide = 2657,
		KeyboardNumpadPlusMinus = 2658,
		KeyboardNumpadClear = 2659,
		KeyboardNumpadClearEntry = 2660,
		KeyboardNumpadBinary = 2661,
		KeyboardNumpadOctal = 2662,
		KeyboardNumpadDecimal = 2663,
		KeyboardNumpadHexadecimal = 2664,
		KeyboardControlLeft = 2667,
		KeyboardShiftLeft = 2668,
		KeyboardAltLeft = 2669,
		KeyboardGUILeft = 2670,
		KeyboardControlRight = 2671,
		KeyboardShiftRight = 2672,
		KeyboardAltRight = 2673,
		KeyboardGUIRight = 2674,
		KeyboardMode = 2700,
		KeyboardAudioNext = 2701,
		KeyboardAudioPrev = 2702,
		KeyboardAudioStop = 2703,
		KeyboardAudioPlay = 2704,
		KeyboardAudioMute = 2705,
		KeyboardMediaSelect = 2706,
		KeyboardWWW = 2707,
		KeyboardMail = 2708,
		KeyboardCalculator = 2709,
		KeyboardComputer = 2710,
		KeyboardACSearch = 2711,
		KeyboardACHome = 2712,
		KeyboardACBack = 2713,
		KeyboardACForward = 2714,
		KeyboardACStop = 2715,
		KeyboardACRefresh = 2716,
		KeyboardACBookmarks = 2717,
		KeyboardBrightnessDown = 2718,
		KeyboardBrightnessUp = 2719,
		KeyboardDisplaySwitch = 2720,
		KeyboardIlluminationToggle = 2721,
		KeyboardIlluminationDown = 2722,
		KeyboardIlluminationUp = 2723,
		KeyboardEject = 2724,
		KeyboardSleep = 2725,

		//gamepads
		GamepadA = 3000,
		GamepadB = 3001,
		GamepadX = 3002,
		GamepadY = 3003,
		GamepadBack = 3004,
		GamepadHome = 3005,
		GamepadStart = 3006,
		GamepadLeftStick = 3007,
		GamepadRightStick = 3008,
		GamepadLeftBumper = 3009,
		GamepadRightBumper = 3010,
		GamepadDpadUp = 3011,
		GamepadDpadDown = 3012,
		GamepadDpadLeft = 3013,
		GamepadDpadRight = 3014,
		GamepadLeftStickLeft = 3015,
		GamepadLeftStickRight = 3016,
		GamepadLeftStickUp = 3017,
		GamepadLeftStickDown = 3018,
		GamepadRightStickLeft = 3019,
		GamepadRightStickRight = 3020,
		GamepadRightStickUp = 3021,
		GamepadRightStickDown = 3022,
		GamepadLeftTrigger = 3024,
		GamepadRightTrigger = 3026
	}
}