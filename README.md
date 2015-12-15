# Introduction
BandsInTownUWP is a windows 10 Universal Windows platform SDK for the [Bands In Town](http://www.bandsintown.com/api/overview) API. This is a pretty straight forward implementation of Bands In Town api as an attempt to build a Windows 10 client for the API. This will serve as a tutorial on how to use [Caliburn Micro framework](http://caliburnmicro.com/) for Windows 10 applications. 

#### Steps to Install the Caliburn Micro framework on the UWP application
1. Create a Universal application and call it BandsInTownUWP.
2. Right click on the BandsInTownUWP and rename it to BandsInTownUI. 
3. Right click on the BandsInTownUI project and select Manage NuGet Packages.
4. Navigate to browse tab and in the search box type "Caliburn micro."
5. Download the first link that appears in the result list.

#### Steps to setup the Caliburn Micro framework in the UWP application
In the BandsInTownUI project, open App.Xaml.cs

Just above the App constuctor add ```private WinRTContainer _container;``` which is defining the main container for the application.

Remove the App.xaml.cs implementing the ```Application``` interface. Just remove the ```:Application``` next to ```App:Application```
Since UWP is based on WinRT, we don't use a bootstrapper.The reason for this is that Windows.UI.Xaml.Application exposes most of    it's functionality through method overrides and not events.

So add these functions in the App.xaml.cs class,

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
Instead of creating a new Bootstrapper in WinRT replace the existing Application with as shown below

Open App.xaml and paste the code below, 
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
  
There are two approaches for displaying the root frame in Caliburn Micro framework. One is by using the View First approach the other is using the ViewModel first approach. UWP applications are meant to work with a large number of device families and hence we need to try and work with the best suitable approach from the list of two above. The best solution is to use the ViewModel approach because the on Windows phones, the navigation is tightly coupled with the hardware. For example: the back button. But again, if you are targetting your app just for desktop then you can try and use the View First Approach.

So here's what you need to do now, 
In the BandsInTownUI application, create a folder called ViewModels and create a class called TestViewModel.cs. Once that is done, open App.xaml.cs and make your OnLaunched() events look like this, 

```csharp
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    DisplayRootViewFor<TestViewModel>();
}
```

#### How to setup services and constructor injection
For ease of explanation, i will show you how to setup a part of ArtistInformationService and inject the service into the TestViewModel that you created in the previous step. 

Firtly, you will have to create a HttpManager class. You can do this in the same project but i would recommend to separate the concerns but having a different class library. Follow the steps below, 
1. Create a new project(class library) and call it HttpManager. 
2. Right click on HttpManager and click on NuGet packages and in the search box under browse type json and installed the Newtonsoft json.net package. 
3. Now create a new class called HttpClientManager.cs under the HttpManager class and add the simplest code to make a http request as shown below,

First create a single pattern to make sure just one instance is created for the cass
```csharp











