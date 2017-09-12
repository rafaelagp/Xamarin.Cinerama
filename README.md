# Xamarin.Cinerama
A sample Xamarin.Forms app

### Special build instructions
None.

### Third party libraries used
* Newtonsoft.Json - For any project that deals with json, this is definetely the go-to lib.
* Fody.PropertyChanged - A staple for any Xamarin MVVM project, it implements the INotifyPropertyChanged interface with a single annotation.
* Prism.Unity - To help in keeping with the MVVM pattern, Prism with Unity dependency injection is probably the best choice. Besides being supported by Microsoft, Miguel De Icaza himself recommended it at Evolve 2016.
* FFImageLoading - Daniel Luberda's library is another staple at any Xamarin project. Deals very well with image caching and has a lot useful built in features like async download of image urls.
* Xam.Plugin.Connectivity - A simple cross-platform abstraction for handling connectivity in class library projects, thanks to James Montemagno.

### Other
* .NETStandard - PCL is on it's way out, so I opted for a .NETStandard 1.6 class library instead.
* OrientationContentPage - Custom code behind by Norman McKay to handle page orientation changes.
* ListViewPagingBehavior - An infinite scrolling behavior developed by Rasmus Christensen.
