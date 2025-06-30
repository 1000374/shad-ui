﻿using System;
using System.IO;
using Avalonia;
using CommunityToolkit.Mvvm.Messaging;
using Jab;
using Serilog;
using ShadUI.Demo.ViewModels;

namespace ShadUI.Demo;

[ServiceProvider]
[Transient<AboutViewModel>]
[Transient<AvatarViewModel>]
[Transient<ButtonViewModel>]
[Transient<CardViewModel>]
[Transient<DataTableViewModel>]
[Transient<DateViewModel>]
[Transient<CheckBoxViewModel>]
[Transient<ComboBoxViewModel>]
[Transient<ColorViewModel>]
[Transient<DashboardViewModel>]
[Transient<DialogViewModel>]
[Transient<InputViewModel>]
[Transient<NumericViewModel>]
[Transient<LoginViewModel>]
[Transient<MenuViewModel>]
[Transient<MiscellaneousViewModel>]
[Transient<SidebarViewModel>]
[Transient<SliderViewModel>]
[Transient<SwitchViewModel>]
[Transient<TabControlViewModel>]
[Transient<TimeViewModel>]
[Transient<ThemeViewModel>]
[Transient<ToastViewModel>]
[Transient<ToggleViewModel>]
[Transient<ToolTipViewModel>]
[Transient<TypographyViewModel>]
[Transient<MainWindowViewModel>]
[Import<IUtilitiesModule>]
[Singleton<IMessenger, WeakReferenceMessenger>]
[Singleton(typeof(ThemeWatcher), Factory = nameof(ThemeWatcherFactory))]
[Singleton(typeof(ILogger), Factory = nameof(LoggerFactory))]
public partial class ServiceProvider
{
    public ILogger LoggerFactory()
    {
        var currentFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ShadUI\\logs");

        Directory.CreateDirectory(currentFolder); //ensure the directory exists

        var file = Path.Combine(currentFolder, "log.txt");

        var config = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(file, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Logger = config; //set the global logger

        return config;
    }

    public ThemeWatcher ThemeWatcherFactory()
    {
        return new ThemeWatcher(Application.Current!);
    }
}