/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Collections.Generic;

namespace Pablo
{
    /// <summary>
    /// Holds a rich set of colors by their common name.
    /// </summary>
    public static class Colors
    {

        /// <summary> 
        /// The <see cref="Color"/> AliceBlue rgb(240, 248, 255).
        /// </summary>
        public static readonly Color AliceBlue = new Color(240, 248, 255);

        /// <summary> 
        /// The <see cref="Color"/> AntiqueWhite rgb(250, 235, 215).
        /// </summary>
        public static readonly Color AntiqueWhite = new Color(250, 235, 215);

        /// <summary> 
        /// The <see cref="Color"/> Aqua rgb(0, 255, 255).
        /// </summary>
        public static readonly Color Aqua = new Color(0, 255, 255);

        /// <summary> 
        /// The <see cref="Color"/> Aquamarine rgb(128, 255, 212).
        /// </summary>
        public static readonly Color Aquamarine = new Color(128, 255, 212);

        /// <summary> 
        /// The <see cref="Color"/> Azure rgb(240, 255, 255).
        /// </summary>
        public static readonly Color Azure = new Color(240, 255, 255);

        /// <summary> 
        /// The <see cref="Color"/> Beige rgb(245, 245, 220).
        /// </summary>
        public static readonly Color Beige = new Color(245, 245, 220);

        /// <summary> 
        /// The <see cref="Color"/> Bisque rgb(255, 227, 197).
        /// </summary>
        public static readonly Color Bisque = new Color(255, 227, 197);

        /// <summary> 
        /// The <see cref="Color"/> Black rgb(0, 0, 0).
        /// </summary>
        public static readonly Color Black = new Color(0, 0, 0);

        /// <summary> 
        /// The <see cref="Color"/> BlanchedAlmond rgb(255, 235, 204).
        /// </summary>
        public static readonly Color BlanchedAlmond = new Color(255, 235, 204);

        /// <summary> 
        /// The <see cref="Color"/> Blue rgb(0, 0, 255).
        /// </summary>
        public static readonly Color Blue = new Color(0, 0, 255);

        /// <summary> 
        /// The <see cref="Color"/> BlueViolet rgb(138, 44, 227).
        /// </summary>
        public static readonly Color BlueViolet = new Color(138, 44, 227);

        /// <summary> 
        /// The <see cref="Color"/> Brown rgb(166, 41, 41).
        /// </summary>
        public static readonly Color Brown = new Color(166, 41, 41);

        /// <summary> 
        /// The <see cref="Color"/> Burlywood rgb(222, 184, 136).
        /// </summary>
        public static readonly Color Burlywood = new Color(222, 184, 136);

        /// <summary> 
        /// The <see cref="Color"/> CadetBlue rgb(95, 159, 161).
        /// </summary>
        public static readonly Color CadetBlue = new Color(95, 159, 161);

        /// <summary> 
        /// The <see cref="Color"/> Chartreuse rgb(128, 255, 0).
        /// </summary>
        public static readonly Color Chartreuse = new Color(128, 255, 0);

        /// <summary> 
        /// The <see cref="Color"/> Chocolate rgb(210, 105, 31).
        /// </summary>
        public static readonly Color Chocolate = new Color(210, 105, 31);

        /// <summary> 
        /// The <see cref="Color"/> Coral rgb(255, 128, 80).
        /// </summary>
        public static readonly Color Coral = new Color(255, 128, 80);

        /// <summary> 
        /// The <see cref="Color"/> Cornflower rgb(100, 148, 238).
        /// </summary>
        public static readonly Color Cornflower = new Color(100, 148, 238);

        /// <summary> 
        /// The <see cref="Color"/> Cornsilk rgb(255, 248, 220).
        /// </summary>
        public static readonly Color Cornsilk = new Color(255, 248, 220);

        /// <summary> 
        /// The <see cref="Color"/> Crimson rgb(220, 21, 62).
        /// </summary>
        public static readonly Color Crimson = new Color(220, 21, 62);

        /// <summary> 
        /// The <see cref="Color"/> Cyan rgb(0, 255, 255).
        /// </summary>
        public static readonly Color Cyan = new Color(0, 255, 255);

        /// <summary> 
        /// The <see cref="Color"/> DarkBlue rgb(0, 0, 141).
        /// </summary>
        public static readonly Color DarkBlue = new Color(0, 0, 141);

        /// <summary> 
        /// The <see cref="Color"/> DarkCyan rgb(0, 141, 141).
        /// </summary>
        public static readonly Color DarkCyan = new Color(0, 141, 141);

        /// <summary> 
        /// The <see cref="Color"/> DarkGoldenrod rgb(184, 136, 11).
        /// </summary>
        public static readonly Color DarkGoldenrod = new Color(184, 136, 11);

        /// <summary> 
        /// The <see cref="Color"/> DarkGray rgb(169, 169, 169).
        /// </summary>
        public static readonly Color DarkGray = new Color(169, 169, 169);

        /// <summary> 
        /// The <see cref="Color"/> DarkGreen rgb(0, 100, 0).
        /// </summary>
        public static readonly Color DarkGreen = new Color(0, 100, 0);

        /// <summary> 
        /// The <see cref="Color"/> DarkKhaki rgb(189, 184, 108).
        /// </summary>
        public static readonly Color DarkKhaki = new Color(189, 184, 108);

        /// <summary> 
        /// The <see cref="Color"/> DarkMagenta rgb(141, 0, 141).
        /// </summary>
        public static readonly Color DarkMagenta = new Color(141, 0, 141);

        /// <summary> 
        /// The <see cref="Color"/> DarkOliveGreen rgb(85, 108, 46).
        /// </summary>
        public static readonly Color DarkOliveGreen = new Color(85, 108, 46);

        /// <summary> 
        /// The <see cref="Color"/> DarkOrange rgb(255, 141, 0).
        /// </summary>
        public static readonly Color DarkOrange = new Color(255, 141, 0);

        /// <summary> 
        /// The <see cref="Color"/> DarkOrchid rgb(153, 51, 204).
        /// </summary>
        public static readonly Color DarkOrchid = new Color(153, 51, 204);

        /// <summary> 
        /// The <see cref="Color"/> DarkRed rgb(141, 0, 0).
        /// </summary>
        public static readonly Color DarkRed = new Color(141, 0, 0);

        /// <summary> 
        /// The <see cref="Color"/> DarkSalmon rgb(233, 151, 123).
        /// </summary>
        public static readonly Color DarkSalmon = new Color(233, 151, 123);

        /// <summary> 
        /// The <see cref="Color"/> DarkSeaGreen rgb(143, 189, 143).
        /// </summary>
        public static readonly Color DarkSeaGreen = new Color(143, 189, 143);

        /// <summary> 
        /// The <see cref="Color"/> DarkSlateBlue rgb(72, 62, 141).
        /// </summary>
        public static readonly Color DarkSlateBlue = new Color(72, 62, 141);

        /// <summary> 
        /// The <see cref="Color"/> DarkSlateGray rgb(46, 80, 80).
        /// </summary>
        public static readonly Color DarkSlateGray = new Color(46, 80, 80);

        /// <summary> 
        /// The <see cref="Color"/> DarkTurquoise rgb(0, 207, 210).
        /// </summary>
        public static readonly Color DarkTurquoise = new Color(0, 207, 210);

        /// <summary> 
        /// The <see cref="Color"/> DarkViolet rgb(148, 0, 212).
        /// </summary>
        public static readonly Color DarkViolet = new Color(148, 0, 212);

        /// <summary> 
        /// The <see cref="Color"/> DeepPink rgb(255, 21, 148).
        /// </summary>
        public static readonly Color DeepPink = new Color(255, 21, 148);

        /// <summary> 
        /// The <see cref="Color"/> DeepSkyBlue rgb(0, 192, 255).
        /// </summary>
        public static readonly Color DeepSkyBlue = new Color(0, 192, 255);

        /// <summary> 
        /// The <see cref="Color"/> DimGray rgb(105, 105, 105).
        /// </summary>
        public static readonly Color DimGray = new Color(105, 105, 105);

        /// <summary> 
        /// The <see cref="Color"/> DodgerBlue rgb(31, 143, 255).
        /// </summary>
        public static readonly Color DodgerBlue = new Color(31, 143, 255);

        /// <summary> 
        /// The <see cref="Color"/> Firebrick rgb(179, 34, 34).
        /// </summary>
        public static readonly Color Firebrick = new Color(179, 34, 34);

        /// <summary> 
        /// The <see cref="Color"/> FloralWhite rgb(255, 250, 240).
        /// </summary>
        public static readonly Color FloralWhite = new Color(255, 250, 240);

        /// <summary> 
        /// The <see cref="Color"/> ForestGreen rgb(34, 141, 34).
        /// </summary>
        public static readonly Color ForestGreen = new Color(34, 141, 34);

        /// <summary> 
        /// The <see cref="Color"/> Fuchsia rgb(255, 0, 255).
        /// </summary>
        public static readonly Color Fuchsia = new Color(255, 0, 255);

        /// <summary> 
        /// The <see cref="Color"/> Gainsboro rgb(220, 220, 220).
        /// </summary>
        public static readonly Color Gainsboro = new Color(220, 220, 220);

        /// <summary> 
        /// The <see cref="Color"/> GhostWhite rgb(248, 248, 255).
        /// </summary>
        public static readonly Color GhostWhite = new Color(248, 248, 255);

        /// <summary> 
        /// The <see cref="Color"/> Gold rgb(255, 215, 0).
        /// </summary>
        public static readonly Color Gold = new Color(255, 215, 0);

        /// <summary> 
        /// The <see cref="Color"/> Goldenrod rgb(217, 166, 34).
        /// </summary>
        public static readonly Color Goldenrod = new Color(217, 166, 34);

        /// <summary> 
        /// The <see cref="Color"/> Gray rgb(192, 192, 192).
        /// </summary>
        public static readonly Color Gray = new Color(192, 192, 192);

        /// <summary> 
        /// The <see cref="Color"/> WebGray rgb(128, 128, 128).
        /// </summary>
        public static readonly Color WebGray = new Color(128, 128, 128);

        /// <summary> 
        /// The <see cref="Color"/> Green rgb(0, 255, 0).
        /// </summary>
        public static readonly Color Green = new Color(0, 255, 0);

        /// <summary> 
        /// The <see cref="Color"/> WebGreen rgb(0, 128, 0).
        /// </summary>
        public static readonly Color WebGreen = new Color(0, 128, 0);

        /// <summary> 
        /// The <see cref="Color"/> GreenYellow rgb(174, 255, 46).
        /// </summary>
        public static readonly Color GreenYellow = new Color(174, 255, 46);

        /// <summary> 
        /// The <see cref="Color"/> Honeydew rgb(240, 255, 240).
        /// </summary>
        public static readonly Color Honeydew = new Color(240, 255, 240);

        /// <summary> 
        /// The <see cref="Color"/> HotPink rgb(255, 105, 182).
        /// </summary>
        public static readonly Color HotPink = new Color(255, 105, 182);

        /// <summary> 
        /// The <see cref="Color"/> IndianRed rgb(204, 92, 92).
        /// </summary>
        public static readonly Color IndianRed = new Color(204, 92, 92);

        /// <summary> 
        /// The <see cref="Color"/> Indigo rgb(74, 0, 131).
        /// </summary>
        public static readonly Color Indigo = new Color(74, 0, 131);

        /// <summary> 
        /// The <see cref="Color"/> Ivory rgb(255, 255, 240).
        /// </summary>
        public static readonly Color Ivory = new Color(255, 255, 240);

        /// <summary> 
        /// The <see cref="Color"/> Khaki rgb(240, 230, 141).
        /// </summary>
        public static readonly Color Khaki = new Color(240, 230, 141);

        /// <summary> 
        /// The <see cref="Color"/> Lavender rgb(230, 230, 250).
        /// </summary>
        public static readonly Color Lavender = new Color(230, 230, 250);

        /// <summary> 
        /// The <see cref="Color"/> LavenderBlush rgb(255, 240, 245).
        /// </summary>
        public static readonly Color LavenderBlush = new Color(255, 240, 245);

        /// <summary> 
        /// The <see cref="Color"/> LawnGreen rgb(125, 253, 0).
        /// </summary>
        public static readonly Color LawnGreen = new Color(125, 253, 0);

        /// <summary> 
        /// The <see cref="Color"/> LemonChiffon rgb(255, 250, 204).
        /// </summary>
        public static readonly Color LemonChiffon = new Color(255, 250, 204);

        /// <summary> 
        /// The <see cref="Color"/> LightBlue rgb(174, 217, 230).
        /// </summary>
        public static readonly Color LightBlue = new Color(174, 217, 230);

        /// <summary> 
        /// The <see cref="Color"/> LightCoral rgb(240, 128, 128).
        /// </summary>
        public static readonly Color LightCoral = new Color(240, 128, 128);

        /// <summary> 
        /// The <see cref="Color"/> LightCyan rgb(225, 255, 255).
        /// </summary>
        public static readonly Color LightCyan = new Color(225, 255, 255);

        /// <summary> 
        /// The <see cref="Color"/> LightGoldenrod rgb(250, 250, 210).
        /// </summary>
        public static readonly Color LightGoldenrod = new Color(250, 250, 210);

        /// <summary> 
        /// The <see cref="Color"/> LightGray rgb(212, 212, 212).
        /// </summary>
        public static readonly Color LightGray = new Color(212, 212, 212);

        /// <summary> 
        /// The <see cref="Color"/> LightGreen rgb(143, 238, 143).
        /// </summary>
        public static readonly Color LightGreen = new Color(143, 238, 143);

        /// <summary> 
        /// The <see cref="Color"/> LightPink rgb(255, 182, 194).
        /// </summary>
        public static readonly Color LightPink = new Color(255, 182, 194);

        /// <summary> 
        /// The <see cref="Color"/> LightSalmon rgb(255, 161, 123).
        /// </summary>
        public static readonly Color LightSalmon = new Color(255, 161, 123);

        /// <summary> 
        /// The <see cref="Color"/> LightSeaGreen rgb(34, 179, 171).
        /// </summary>
        public static readonly Color LightSeaGreen = new Color(34, 179, 171);

        /// <summary> 
        /// The <see cref="Color"/> LightSkyBlue rgb(136, 207, 250).
        /// </summary>
        public static readonly Color LightSkyBlue = new Color(136, 207, 250);

        /// <summary> 
        /// The <see cref="Color"/> LightSlateGray rgb(120, 136, 153).
        /// </summary>
        public static readonly Color LightSlateGray = new Color(120, 136, 153);

        /// <summary> 
        /// The <see cref="Color"/> LightSteelBlue rgb(176, 197, 222).
        /// </summary>
        public static readonly Color LightSteelBlue = new Color(176, 197, 222);

        /// <summary> 
        /// The <see cref="Color"/> LightYellow rgb(255, 255, 225).
        /// </summary>
        public static readonly Color LightYellow = new Color(255, 255, 225);

        /// <summary> 
        /// The <see cref="Color"/> Lime rgb(0, 255, 0).
        /// </summary>
        public static readonly Color Lime = new Color(0, 255, 0);

        /// <summary> 
        /// The <see cref="Color"/> LimeGreen rgb(51, 204, 51).
        /// </summary>
        public static readonly Color LimeGreen = new Color(51, 204, 51);

        /// <summary> 
        /// The <see cref="Color"/> Linen rgb(250, 240, 230).
        /// </summary>
        public static readonly Color Linen = new Color(250, 240, 230);

        /// <summary> 
        /// The <see cref="Color"/> Magenta rgb(255, 0, 255).
        /// </summary>
        public static readonly Color Magenta = new Color(255, 0, 255);

        /// <summary> 
        /// The <see cref="Color"/> Maroon rgb(176, 49, 97).
        /// </summary>
        public static readonly Color Maroon = new Color(176, 49, 97);

        /// <summary> 
        /// The <see cref="Color"/> WebMaroon rgb(128, 0, 0).
        /// </summary>
        public static readonly Color WebMaroon = new Color(128, 0, 0);

        /// <summary> 
        /// The <see cref="Color"/> MediumAquamarine rgb(102, 204, 171).
        /// </summary>
        public static readonly Color MediumAquamarine = new Color(102, 204, 171);

        /// <summary> 
        /// The <see cref="Color"/> MediumBlue rgb(0, 0, 204).
        /// </summary>
        public static readonly Color MediumBlue = new Color(0, 0, 204);

        /// <summary> 
        /// The <see cref="Color"/> MediumOrchid rgb(187, 85, 212).
        /// </summary>
        public static readonly Color MediumOrchid = new Color(187, 85, 212);

        /// <summary> 
        /// The <see cref="Color"/> MediumPurple rgb(148, 113, 220).
        /// </summary>
        public static readonly Color MediumPurple = new Color(148, 113, 220);

        /// <summary> 
        /// The <see cref="Color"/> MediumSeaGreen rgb(62, 179, 113).
        /// </summary>
        public static readonly Color MediumSeaGreen = new Color(62, 179, 113);

        /// <summary> 
        /// The <see cref="Color"/> MediumSlateBlue rgb(123, 105, 238).
        /// </summary>
        public static readonly Color MediumSlateBlue = new Color(123, 105, 238);

        /// <summary> 
        /// The <see cref="Color"/> MediumSpringGreen rgb(0, 250, 153).
        /// </summary>
        public static readonly Color MediumSpringGreen = new Color(0, 250, 153);

        /// <summary> 
        /// The <see cref="Color"/> MediumTurquoise rgb(72, 210, 204).
        /// </summary>
        public static readonly Color MediumTurquoise = new Color(72, 210, 204);

        /// <summary> 
        /// The <see cref="Color"/> MediumVioletRed rgb(199, 21, 133).
        /// </summary>
        public static readonly Color MediumVioletRed = new Color(199, 21, 133);

        /// <summary> 
        /// The <see cref="Color"/> MidnightBlue rgb(26, 26, 113).
        /// </summary>
        public static readonly Color MidnightBlue = new Color(26, 26, 113);

        /// <summary> 
        /// The <see cref="Color"/> MintCream rgb(245, 255, 250).
        /// </summary>
        public static readonly Color MintCream = new Color(245, 255, 250);

        /// <summary> 
        /// The <see cref="Color"/> MistyRose rgb(255, 227, 225).
        /// </summary>
        public static readonly Color MistyRose = new Color(255, 227, 225);

        /// <summary> 
        /// The <see cref="Color"/> Moccasin rgb(255, 227, 182).
        /// </summary>
        public static readonly Color Moccasin = new Color(255, 227, 182);

        /// <summary> 
        /// The <see cref="Color"/> NavajoWhite rgb(255, 222, 174).
        /// </summary>
        public static readonly Color NavajoWhite = new Color(255, 222, 174);

        /// <summary> 
        /// The <see cref="Color"/> NavyBlue rgb(0, 0, 128).
        /// </summary>
        public static readonly Color NavyBlue = new Color(0, 0, 128);

        /// <summary> 
        /// The <see cref="Color"/> OldLace rgb(253, 245, 230).
        /// </summary>
        public static readonly Color OldLace = new Color(253, 245, 230);

        /// <summary> 
        /// The <see cref="Color"/> Olive rgb(128, 128, 0).
        /// </summary>
        public static readonly Color Olive = new Color(128, 128, 0);

        /// <summary> 
        /// The <see cref="Color"/> OliveDrab rgb(108, 143, 36).
        /// </summary>
        public static readonly Color OliveDrab = new Color(108, 143, 36);

        /// <summary> 
        /// The <see cref="Color"/> Orange rgb(255, 166, 0).
        /// </summary>
        public static readonly Color Orange = new Color(255, 166, 0);

        /// <summary> 
        /// The <see cref="Color"/> OrangeRed rgb(255, 69, 0).
        /// </summary>
        public static readonly Color OrangeRed = new Color(255, 69, 0);

        /// <summary> 
        /// The <see cref="Color"/> Orchid rgb(217, 113, 215).
        /// </summary>
        public static readonly Color Orchid = new Color(217, 113, 215);

        /// <summary> 
        /// The <see cref="Color"/> PaleGoldenrod rgb(238, 233, 171).
        /// </summary>
        public static readonly Color PaleGoldenrod = new Color(238, 233, 171);

        /// <summary> 
        /// The <see cref="Color"/> PaleGreen rgb(153, 250, 153).
        /// </summary>
        public static readonly Color PaleGreen = new Color(153, 250, 153);

        /// <summary> 
        /// The <see cref="Color"/> PaleTurquoise rgb(176, 238, 238).
        /// </summary>
        public static readonly Color PaleTurquoise = new Color(176, 238, 238);

        /// <summary> 
        /// The <see cref="Color"/> PaleVioletRed rgb(220, 113, 148).
        /// </summary>
        public static readonly Color PaleVioletRed = new Color(220, 113, 148);

        /// <summary> 
        /// The <see cref="Color"/> PapayaWhip rgb(255, 240, 215).
        /// </summary>
        public static readonly Color PapayaWhip = new Color(255, 240, 215);

        /// <summary> 
        /// The <see cref="Color"/> PeachPuff rgb(255, 217, 187).
        /// </summary>
        public static readonly Color PeachPuff = new Color(255, 217, 187);

        /// <summary> 
        /// The <see cref="Color"/> Peru rgb(204, 133, 64).
        /// </summary>
        public static readonly Color Peru = new Color(204, 133, 64);

        /// <summary> 
        /// The <see cref="Color"/> Pink rgb(255, 192, 204).
        /// </summary>
        public static readonly Color Pink = new Color(255, 192, 204);

        /// <summary> 
        /// The <see cref="Color"/> Plum rgb(222, 161, 222).
        /// </summary>
        public static readonly Color Plum = new Color(222, 161, 222);

        /// <summary> 
        /// The <see cref="Color"/> PowderBlue rgb(176, 225, 230).
        /// </summary>
        public static readonly Color PowderBlue = new Color(176, 225, 230);

        /// <summary> 
        /// The <see cref="Color"/> Purple rgb(161, 34, 240).
        /// </summary>
        public static readonly Color Purple = new Color(161, 34, 240);

        /// <summary> 
        /// The <see cref="Color"/> WebPurple rgb(128, 0, 128).
        /// </summary>
        public static readonly Color WebPurple = new Color(128, 0, 128);

        /// <summary> 
        /// The <see cref="Color"/> RebeccaPurple rgb(102, 51, 153).
        /// </summary>
        public static readonly Color RebeccaPurple = new Color(102, 51, 153);

        /// <summary> 
        /// The <see cref="Color"/> Red rgb(255, 0, 0).
        /// </summary>
        public static readonly Color Red = new Color(255, 0, 0);

        /// <summary> 
        /// The <see cref="Color"/> RosyBrown rgb(189, 143, 143).
        /// </summary>
        public static readonly Color RosyBrown = new Color(189, 143, 143);

        /// <summary> 
        /// The <see cref="Color"/> RoyalBlue rgb(64, 105, 225).
        /// </summary>
        public static readonly Color RoyalBlue = new Color(64, 105, 225);

        /// <summary> 
        /// The <see cref="Color"/> SaddleBrown rgb(141, 69, 18).
        /// </summary>
        public static readonly Color SaddleBrown = new Color(141, 69, 18);

        /// <summary> 
        /// The <see cref="Color"/> Salmon rgb(250, 128, 115).
        /// </summary>
        public static readonly Color Salmon = new Color(250, 128, 115);

        /// <summary> 
        /// The <see cref="Color"/> SandyBrown rgb(245, 164, 97).
        /// </summary>
        public static readonly Color SandyBrown = new Color(245, 164, 97);

        /// <summary> 
        /// The <see cref="Color"/> SeaGreen rgb(46, 141, 87).
        /// </summary>
        public static readonly Color SeaGreen = new Color(46, 141, 87);

        /// <summary> 
        /// The <see cref="Color"/> Seashell rgb(255, 245, 238).
        /// </summary>
        public static readonly Color Seashell = new Color(255, 245, 238);

        /// <summary> 
        /// The <see cref="Color"/> Sienna rgb(161, 82, 46).
        /// </summary>
        public static readonly Color Sienna = new Color(161, 82, 46);

        /// <summary> 
        /// The <see cref="Color"/> Silver rgb(192, 192, 192).
        /// </summary>
        public static readonly Color Silver = new Color(192, 192, 192);

        /// <summary> 
        /// The <see cref="Color"/> SkyBlue rgb(136, 207, 235).
        /// </summary>
        public static readonly Color SkyBlue = new Color(136, 207, 235);

        /// <summary> 
        /// The <see cref="Color"/> SlateBlue rgb(108, 90, 204).
        /// </summary>
        public static readonly Color SlateBlue = new Color(108, 90, 204);

        /// <summary> 
        /// The <see cref="Color"/> SlateGray rgb(113, 128, 143).
        /// </summary>
        public static readonly Color SlateGray = new Color(113, 128, 143);

        /// <summary> 
        /// The <see cref="Color"/> Snow rgb(255, 250, 250).
        /// </summary>
        public static readonly Color Snow = new Color(255, 250, 250);

        /// <summary> 
        /// The <see cref="Color"/> SpringGreen rgb(0, 255, 128).
        /// </summary>
        public static readonly Color SpringGreen = new Color(0, 255, 128);

        /// <summary> 
        /// The <see cref="Color"/> SteelBlue rgb(69, 131, 182).
        /// </summary>
        public static readonly Color SteelBlue = new Color(69, 131, 182);

        /// <summary> 
        /// The <see cref="Color"/> Tan rgb(210, 182, 141).
        /// </summary>
        public static readonly Color Tan = new Color(210, 182, 141);

        /// <summary> 
        /// The <see cref="Color"/> Teal rgb(0, 128, 128).
        /// </summary>
        public static readonly Color Teal = new Color(0, 128, 128);

        /// <summary> 
        /// The <see cref="Color"/> Thistle rgb(217, 192, 217).
        /// </summary>
        public static readonly Color Thistle = new Color(217, 192, 217);

        /// <summary> 
        /// The <see cref="Color"/> Tomato rgb(255, 100, 72).
        /// </summary>
        public static readonly Color Tomato = new Color(255, 100, 72);

        /// <summary> 
        /// The <see cref="Color"/> Turquoise rgb(64, 225, 210).
        /// </summary>
        public static readonly Color Turquoise = new Color(64, 225, 210);

        /// <summary> 
        /// The <see cref="Color"/> Violet rgb(238, 131, 238).
        /// </summary>
        public static readonly Color Violet = new Color(238, 131, 238);

        /// <summary> 
        /// The <see cref="Color"/> Wheat rgb(245, 222, 179).
        /// </summary>
        public static readonly Color Wheat = new Color(245, 222, 179);

        /// <summary> 
        /// The <see cref="Color"/> White rgb(255, 255, 255).
        /// </summary>
        public static readonly Color White = new Color(255, 255, 255);

        /// <summary> 
        /// The <see cref="Color"/> WhiteSmoke rgb(245, 245, 245).
        /// </summary>
        public static readonly Color WhiteSmoke = new Color(245, 245, 245);

        /// <summary> 
        /// The <see cref="Color"/> Yellow rgb(255, 255, 0).
        /// </summary>
        public static readonly Color Yellow = new Color(255, 255, 0);

        /// <summary> 
        /// The <see cref="Color"/> YellowGreen rgb(153, 204, 51).
        /// </summary>
        public static readonly Color YellowGreen = new Color(153, 204, 51);

        /// <summary>
        /// The dictionary to hold all the <see cref="Color"/>s for lookups.
        /// </summary>
        /// <remarks>
        /// The comparer is case-insensitive.
        /// </remarks>
        private static readonly Dictionary<string, Color> ColorDictionary
            = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(AliceBlue)] = AliceBlue,
                [nameof(AntiqueWhite)] = AntiqueWhite,
                [nameof(Aqua)] = Aqua,
                [nameof(Aquamarine)] = Aquamarine,
                [nameof(Azure)] = Azure,
                [nameof(Beige)] = Beige,
                [nameof(Bisque)] = Bisque,
                [nameof(Black)] = Black,
                [nameof(BlanchedAlmond)] = BlanchedAlmond,
                [nameof(Blue)] = Blue,
                [nameof(BlueViolet)] = BlueViolet,
                [nameof(Brown)] = Brown,
                [nameof(Burlywood)] = Burlywood,
                [nameof(CadetBlue)] = CadetBlue,
                [nameof(Chartreuse)] = Chartreuse,
                [nameof(Chocolate)] = Chocolate,
                [nameof(Coral)] = Coral,
                [nameof(Cornflower)] = Cornflower,
                [nameof(Cornsilk)] = Cornsilk,
                [nameof(Crimson)] = Crimson,
                [nameof(Cyan)] = Cyan,
                [nameof(DarkBlue)] = DarkBlue,
                [nameof(DarkCyan)] = DarkCyan,
                [nameof(DarkGoldenrod)] = DarkGoldenrod,
                [nameof(DarkGray)] = DarkGray,
                [nameof(DarkGreen)] = DarkGreen,
                [nameof(DarkKhaki)] = DarkKhaki,
                [nameof(DarkMagenta)] = DarkMagenta,
                [nameof(DarkOliveGreen)] = DarkOliveGreen,
                [nameof(DarkOrange)] = DarkOrange,
                [nameof(DarkOrchid)] = DarkOrchid,
                [nameof(DarkRed)] = DarkRed,
                [nameof(DarkSalmon)] = DarkSalmon,
                [nameof(DarkSeaGreen)] = DarkSeaGreen,
                [nameof(DarkSlateBlue)] = DarkSlateBlue,
                [nameof(DarkSlateGray)] = DarkSlateGray,
                [nameof(DarkTurquoise)] = DarkTurquoise,
                [nameof(DarkViolet)] = DarkViolet,
                [nameof(DeepPink)] = DeepPink,
                [nameof(DeepSkyBlue)] = DeepSkyBlue,
                [nameof(DimGray)] = DimGray,
                [nameof(DodgerBlue)] = DodgerBlue,
                [nameof(Firebrick)] = Firebrick,
                [nameof(FloralWhite)] = FloralWhite,
                [nameof(ForestGreen)] = ForestGreen,
                [nameof(Fuchsia)] = Fuchsia,
                [nameof(Gainsboro)] = Gainsboro,
                [nameof(GhostWhite)] = GhostWhite,
                [nameof(Gold)] = Gold,
                [nameof(Goldenrod)] = Goldenrod,
                [nameof(Gray)] = Gray,
                [nameof(WebGray)] = WebGray,
                [nameof(Green)] = Green,
                [nameof(WebGreen)] = WebGreen,
                [nameof(GreenYellow)] = GreenYellow,
                [nameof(Honeydew)] = Honeydew,
                [nameof(HotPink)] = HotPink,
                [nameof(IndianRed)] = IndianRed,
                [nameof(Indigo)] = Indigo,
                [nameof(Ivory)] = Ivory,
                [nameof(Khaki)] = Khaki,
                [nameof(Lavender)] = Lavender,
                [nameof(LavenderBlush)] = LavenderBlush,
                [nameof(LawnGreen)] = LawnGreen,
                [nameof(LemonChiffon)] = LemonChiffon,
                [nameof(LightBlue)] = LightBlue,
                [nameof(LightCoral)] = LightCoral,
                [nameof(LightCyan)] = LightCyan,
                [nameof(LightGoldenrod)] = LightGoldenrod,
                [nameof(LightGray)] = LightGray,
                [nameof(LightGreen)] = LightGreen,
                [nameof(LightPink)] = LightPink,
                [nameof(LightSalmon)] = LightSalmon,
                [nameof(LightSeaGreen)] = LightSeaGreen,
                [nameof(LightSkyBlue)] = LightSkyBlue,
                [nameof(LightSlateGray)] = LightSlateGray,
                [nameof(LightSteelBlue)] = LightSteelBlue,
                [nameof(LightYellow)] = LightYellow,
                [nameof(Lime)] = Lime,
                [nameof(LimeGreen)] = LimeGreen,
                [nameof(Linen)] = Linen,
                [nameof(Magenta)] = Magenta,
                [nameof(Maroon)] = Maroon,
                [nameof(WebMaroon)] = WebMaroon,
                [nameof(MediumAquamarine)] = MediumAquamarine,
                [nameof(MediumBlue)] = MediumBlue,
                [nameof(MediumOrchid)] = MediumOrchid,
                [nameof(MediumPurple)] = MediumPurple,
                [nameof(MediumSeaGreen)] = MediumSeaGreen,
                [nameof(MediumSlateBlue)] = MediumSlateBlue,
                [nameof(MediumSpringGreen)] = MediumSpringGreen,
                [nameof(MediumTurquoise)] = MediumTurquoise,
                [nameof(MediumVioletRed)] = MediumVioletRed,
                [nameof(MidnightBlue)] = MidnightBlue,
                [nameof(MintCream)] = MintCream,
                [nameof(MistyRose)] = MistyRose,
                [nameof(Moccasin)] = Moccasin,
                [nameof(NavajoWhite)] = NavajoWhite,
                [nameof(NavyBlue)] = NavyBlue,
                [nameof(OldLace)] = OldLace,
                [nameof(Olive)] = Olive,
                [nameof(OliveDrab)] = OliveDrab,
                [nameof(Orange)] = Orange,
                [nameof(OrangeRed)] = OrangeRed,
                [nameof(Orchid)] = Orchid,
                [nameof(PaleGoldenrod)] = PaleGoldenrod,
                [nameof(PaleGreen)] = PaleGreen,
                [nameof(PaleTurquoise)] = PaleTurquoise,
                [nameof(PaleVioletRed)] = PaleVioletRed,
                [nameof(PapayaWhip)] = PapayaWhip,
                [nameof(PeachPuff)] = PeachPuff,
                [nameof(Peru)] = Peru,
                [nameof(Pink)] = Pink,
                [nameof(Plum)] = Plum,
                [nameof(PowderBlue)] = PowderBlue,
                [nameof(Purple)] = Purple,
                [nameof(WebPurple)] = WebPurple,
                [nameof(RebeccaPurple)] = RebeccaPurple,
                [nameof(Red)] = Red,
                [nameof(RosyBrown)] = RosyBrown,
                [nameof(RoyalBlue)] = RoyalBlue,
                [nameof(SaddleBrown)] = SaddleBrown,
                [nameof(Salmon)] = Salmon,
                [nameof(SandyBrown)] = SandyBrown,
                [nameof(SeaGreen)] = SeaGreen,
                [nameof(Seashell)] = Seashell,
                [nameof(Sienna)] = Sienna,
                [nameof(Silver)] = Silver,
                [nameof(SkyBlue)] = SkyBlue,
                [nameof(SlateBlue)] = SlateBlue,
                [nameof(SlateGray)] = SlateGray,
                [nameof(Snow)] = Snow,
                [nameof(SpringGreen)] = SpringGreen,
                [nameof(SteelBlue)] = SteelBlue,
                [nameof(Tan)] = Tan,
                [nameof(Teal)] = Teal,
                [nameof(Thistle)] = Thistle,
                [nameof(Tomato)] = Tomato,
                [nameof(Turquoise)] = Turquoise,
                [nameof(Violet)] = Violet,
                [nameof(Wheat)] = Wheat,
                [nameof(White)] = White,
                [nameof(WhiteSmoke)] = WhiteSmoke,
                [nameof(Yellow)] = Yellow,
                [nameof(YellowGreen)] = YellowGreen,
            };

        /// <summary>
        /// Checks to see if the given name is a <see cref="Color"/> name.
        /// </summary>
        /// <remarks>
        /// name is case-insensitive.
        /// </remarks>
        public static bool NameExists(string name)
            => ColorDictionary != null && ColorDictionary.ContainsKey(name);

        /// <summary>
        /// Gets the <see cref="Color"/> corresponding with the provided name.
        /// </summary>
        /// <remarks>
        /// name is case-insensitive.
        /// </remarks>
        /// <exception cref="InvalidOperationException"> name is not a color name</exception>
        /// <exception cref="ArgumentNullException"> name is null</exception>
        public static Color GetColor(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (!ColorDictionary.ContainsKey(name))
                throw new InvalidOperationException($"\"{name}\" is not a valid name for a color.");

            return ColorDictionary[name];
        }
    }
}