# Introduction
BandsInTownUWP is a windows 10 Universal Windows platform SDK for the [Bands In Town](http://www.bandsintown.com/api/overview) API. This is a pretty straight forward implementation of Bands In Town api as an attempt to build a Windows 10 client for the API. This will serve as a tutorial on how to use [Caliburn Micro framework](http://caliburnmicro.com/) for Windows 10 applications. 

#### Steps to Install the Caliburn Micro framework on the UWP application
1. Create a Universal application and call it BandsInTownUWP.
2. Right click on the BandsInTownUWP and rename it to BandsInTownUI. 
3. Right click on the BandsInTownUI project and select Manage NuGet Packages.
4. Navigate to browse tab and in the search box type "Caliburn micro."
5. Download the first link that appears in the result list.

#### Steps to setup the Caliburn Micro framework in the UWP application
1. In the BandsInTownUI project, open App.Xaml.cs
2. Just above the App constuctor add ```private WinRTContainer _container;``` which is defining the main container for the application.
3. Remove the App.xaml.cs implementing the ```Application``` interface. Just remove the ```:Application``` next to ```App:Application```
4. Add the this function in the App.xaml.cs class,
   ```csharp
   protected override void Configure()
   {
       _container = new WinRTContainer();
       _container.RegisterWinRTServices();
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
  ```
5. Open App.xaml and paste the code below, 
```
<cm:CaliburnApplication
     x:Class="BandsInTownUWP.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:BandsInTownUWP"
    xmlns:cm="using:Caliburn.Micro"
    RequestedTheme="Light">

</cm:CaliburnApplication>
```
Now the Caliburn Micro framework is setup on your application. Though Caliburn Micro might feel a bit hard to use initially, it is pretty slick. It makes our life really simple. We don't have to reinvent the wheel to implement MVVM pattern in our application. The Caliburn Micro framework does the magic. 
  
    






