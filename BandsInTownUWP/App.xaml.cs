﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using BandsInTownUWP.IServices;
using BandsInTownUWP.Services;
using BandsInTownUWP.ViewModels;

namespace BandsInTownUWP
{
    public sealed partial class App
    {
        private WinRTContainer _container;

        public App()
        {
            this.InitializeComponent();
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container.PerRequest<TestViewModel>();
            _container.Singleton<IArtistInformationService, ArtistInformationService>();
            _container.Singleton<IGeoCoderService, GeoCoderService>();
            _container.Singleton<IPopularEventsNearbyService, PopularEventsNearbyService>();
            _container.Singleton<IJustAnnouncedEventsService, JustAnnouncedEventsService>();
            _container.Singleton<IRecommendedArtists, RecommendedArtists>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            DisplayRootViewFor<TestViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
