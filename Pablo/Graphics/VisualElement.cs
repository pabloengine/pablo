/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

namespace Pablo.Graphics
{
    /// <summary>
    /// Base type for all visual elements.
    /// </summary>
    public abstract class VisualElement : HierarchicalObject
    {
        /// <summary>
        /// Identifies the <see cref="BackgroundBrush"/> <see cref="HierarchicalProperty"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public static readonly HierarchicalProperty BackgroundBrushProperty
            = RegisterProperty(typeof(VisualElement), nameof(BackgroundBrush), typeof(Brush));

        /// <summary>
        /// Identifies the <see cref="ForegroundBrush"/> <see cref="HierarchicalProperty"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public static readonly HierarchicalProperty ForegroundBrushProperty
            = RegisterProperty(typeof(VisualElement), nameof(ForegroundBrush), typeof(Brush), true);

        /// <summary>
        /// Identifies the <see cref="FillBrush"/> <see cref="HierarchicalProperty"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public static readonly HierarchicalProperty FillBrushProperty
            = RegisterProperty(typeof(VisualElement), nameof(FillBrush), typeof(Brush));

        /// <summary>
        /// Identifies the <see cref="StrokeBrush"/> <see cref="HierarchicalProperty"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public static readonly HierarchicalProperty StrokeBrushProperty
            = RegisterProperty(typeof(VisualElement), nameof(StrokeBrush), typeof(Brush), true);

        /// <summary>
        /// Identifies the <see cref="LineJoin"/> <see cref="HierarchicalProperty"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public static readonly HierarchicalProperty LineJoinProperty
            = RegisterProperty(typeof(VisualElement), nameof(LineJoin), typeof(LineJoin));

        /// <summary>
        /// Identifies the <see cref="StrokeType"/> <see cref="HierarchicalProperty"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public static readonly HierarchicalProperty StrokeTypeProperty
            = RegisterProperty(typeof(VisualElement), nameof(StrokeType), typeof(StrokeType));

        /// <summary>
        /// Identifies the <see cref="StrokeScale"/> <see cref="HierarchicalProperty"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public static readonly HierarchicalProperty StrokeScaleProperty
            = RegisterProperty(typeof(VisualElement), nameof(StrokeScale), typeof(double));

        /// <summary>
        /// Identifies the <see cref="StrokeWeight"/> <see cref="HierarchicalProperty"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public static readonly HierarchicalProperty StrokeWeightProperty
            = RegisterProperty(typeof(VisualElement), nameof(StrokeWeight), typeof(double), true,
                defaultFactory: () => 0.1);

        /// <summary>
        /// Gets or sets the background <see cref="Brush"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public Brush BackgroundBrush
        {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }
        /// <summary>
        /// Gets or sets the foreground <see cref="Brush"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public Brush ForegroundBrush
        {
            get { return (Brush)GetValue(ForegroundBrushProperty); }
            set { SetValue(ForegroundBrushProperty, value); }
        }
        /// <summary>
        /// Gets or sets the fill <see cref="Brush"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public Brush FillBrush
        {
            get { return (Brush)GetValue(FillBrushProperty); }
            set { SetValue(FillBrushProperty, value); }
        }
        /// <summary>
        /// Gets or sets the stroke <see cref="Brush"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public Brush StrokeBrush
        {
            get { return (Brush)GetValue(StrokeBrushProperty); }
            set { SetValue(StrokeBrushProperty, value); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Graphics.LineJoin"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public LineJoin LineJoin
        {
            get { return (LineJoin)GetValue(LineJoinProperty); }
            set { SetValue(LineJoinProperty, value); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Graphics.StrokeType"/> of the <see cref="VisualElement"/>.
        /// </summary>
        public StrokeType StrokeType
        {
            get { return (StrokeType)GetValue(StrokeTypeProperty); }
            set { SetValue(StrokeTypeProperty, value); }
        }
        /// <summary>
        /// Gets or sets the stroke scale of the <see cref="VisualElement"/>.
        /// </summary>
        public double StrokeScale
        {
            get { return (double)GetValue(StrokeScaleProperty); }
            set { SetValue(StrokeScaleProperty, value); }
        }
        /// <summary>
        /// Gets or sets the stroke weight of the <see cref="VisualElement"/>.
        /// </summary>
        public double StrokeWeight
        {
            get { return (double)GetValue(StrokeWeightProperty); }
            set { SetValue(StrokeWeightProperty, value); }
        }

    }
}
