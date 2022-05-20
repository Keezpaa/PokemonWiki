using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Web.WebView2.Core;
using PokemonWiki.Contracts.Services;
using PokemonWiki.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonWiki.ViewModels
{
    public class WebViewModel : ObservableRecipient, INavigationAware
    {
        // TODO WTS: Set the URI of the page to show by default
        private const string DefaultUrl = "https://bulbapedia.bulbagarden.net/wiki/Main_Page";
        private Uri _source;
        private bool _isLoading = true;
        private bool _hasFailures;
        private ICommand _browserBackCommand;
        private ICommand _browserForwardCommand;
        private ICommand _openInBrowserCommand;
        private ICommand _reloadCommand;
        private ICommand _retryCommand;

        public IWebViewService WebViewService { get; }

        public Uri Source
        {
            get { return _source; }
            set { SetProperty(ref _source, value); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public bool HasFailures
        {
            get => _hasFailures;
            set => SetProperty(ref _hasFailures, value);
        }

        public ICommand BrowserBackCommand => _browserBackCommand ??= new RelayCommand(
            () => WebViewService?.GoBack(), () => WebViewService?.CanGoBack ?? false);

        public ICommand BrowserForwardCommand => _browserForwardCommand ??= new RelayCommand(
            () => WebViewService?.GoForward(), () => WebViewService?.CanGoForward ?? false);

        public ICommand ReloadCommand => _reloadCommand ??= new RelayCommand(
            () => WebViewService?.Reload());

        public ICommand RetryCommand => _retryCommand ??= new RelayCommand(OnRetry);

        public ICommand OpenInBrowserCommand => _openInBrowserCommand ??= new RelayCommand(async
            () => await Windows.System.Launcher.LaunchUriAsync(Source));

        public WebViewModel(IWebViewService webViewService)
        {
            WebViewService = webViewService;
        }

        public void OnNavigatedTo(object parameter)
        {
            WebViewService.NavigationCompleted += OnNavigationCompleted;
            Source = new Uri(DefaultUrl);
        }

        public void OnNavigatedFrom()
        {
            WebViewService.UnregisterEvents();
            WebViewService.NavigationCompleted -= OnNavigationCompleted;
        }

        private void OnNavigationCompleted(object sender, CoreWebView2WebErrorStatus webErrorStatus)
        {
            IsLoading = false;
            OnPropertyChanged(nameof(BrowserBackCommand));
            OnPropertyChanged(nameof(BrowserForwardCommand));
            if (webErrorStatus != default)
            {
                // Use `webErrorStatus` to vary the displayed message based on the error reason
                HasFailures = true;
            }
        }

        private void OnRetry()
        {
            HasFailures = false;
            IsLoading = true;
            WebViewService?.Reload();
        }
    }
}
