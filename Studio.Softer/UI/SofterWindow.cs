﻿using System.Windows;
using Studio.Softer.Services;
using System.Windows.Controls;
using System.Windows.Interop;
using System;

namespace Studio.Softer.UI
{
    [TemplatePart(Name = PART_DockingHost, Type = typeof(ContentPresenter))]
    public class SofterWindow : Windows.UI.MainWindow
    {
        /// <summary>
        /// Docking Host PART NAME.
        /// </summary>
        private const string PART_DockingHost = "PART_DockingHost";

        /// <summary>
        /// Set default style key property.
        /// </summary>
        static SofterWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SofterWindow),
                new FrameworkPropertyMetadata(typeof(SofterWindow)));
        }

        /// <summary>
        /// Get Default Constructor.
        /// </summary>
        public SofterWindow()
        {
            DataContext = Application.Current.GetService<WorkspaceService>();
        }

        /// <summary>
        /// Allows to get template from xaml.
        /// </summary>
        public override void OnApplyTemplate()
        {
            var scene = GetTemplateChild(PART_DockingHost) as ContentPresenter;
            var window = new WindowInteropHelper(new UI.SplashScreen());
            scene.Content = new HwndHostEx(window.Handle);
            /*Application.Current.GetService<DockManagerService>()
                .GetDockContainerElement(GetTemplateChild(PART_DockingHost) as ContentPresenter);*/
            base.OnApplyTemplate();
        }
    }
}
