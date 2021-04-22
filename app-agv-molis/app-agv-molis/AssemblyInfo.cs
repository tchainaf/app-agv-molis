using Android.App;
using Xamarin.Forms.Xaml;

#if DEBUG
[assembly: Application(Debuggable = true, UsesCleartextTraffic = true)]
#else
[assembly: Application(Debuggable=false, UsesCleartextTraffic = true)]
#endif
