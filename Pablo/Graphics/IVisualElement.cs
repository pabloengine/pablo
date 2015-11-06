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
    /// Represents an element that can be rendered.
    /// </summary>
    public interface IVisualElement
    {
        /// <summary>
        /// Gets the background <see cref="Brush"/> of the <see cref="IVisualElement"/>.
        /// </summary>
        Brush BackgroundBrush { get; }

        /// <summary>
        /// Gets the foreground <see cref="Brush"/> of the <see cref="IVisualElement"/>.
        /// </summary>
        Brush ForegroundBrush { get; }

        /// <summary>
        /// Gets the fill <see cref="Brush"/> of the <see cref="IVisualElement"/>.
        /// </summary>
        Brush FillBrush { get; }

        /// <summary>
        /// Gets the stroke <see cref="Brush"/> of the <see cref="IVisualElement"/>.
        /// </summary>
        Brush StrokeBrush { get; }

        /// <summary>
        /// Gets the <see cref="Graphics.LineJoin"/> of the <see cref="IVisualElement"/>.
        /// </summary>
        LineJoin LineJoin { get; }

        /// <summary>
        /// Gets the <see cref="Graphics.StrokeType"/> of the <see cref="IVisualElement"/>.
        /// </summary>
        StrokeType StrokeType { get; }

        /// <summary>
        /// Gets the stroke scale of the <see cref="IVisualElement"/>.
        /// </summary>
        double StrokeScale { get; }

        /// <summary>
        /// Gets the stroke weight of the <see cref="IVisualElement"/>.
        /// </summary>
        double StrokeWeight { get; }

    }
}
