# WpfButtonRings

A WPF control to arrange buttons as a ring.

![Sample](/img/sample.png)

## Installation

To use the control, you'll need to include the following files into your project:
* ButtonRing.cs
* ButtonRingItem.cs
* ButtonRingMultiValueConverter.cs
* ButtonRingStyle.xaml

Also define the `ButtonRingStyle.xaml` as a global resource inside of your `App.xaml`.
```xml
<Application ...>
    <Application.Resources>
        <ResourceDictionary Source="ButtonRingStyle.xaml" />
    </Application.Resources>
</Application>
```

## How to use

Using the control requires the namespace `xmlns:wpfButtonRings="clr-namespace:Fairybells.WpfButtonRings"` to be included.

### ButtonRing
The `ButtonRing` is the container control. It contains all button instances.
It can be parametrized by the following properties:

* `ControlSize`
* `RingDistance`
* `RingWidth`
* `RingRotation`
* `ButtonDistance`
* `ButtonDistance`
* `RotateContents`
* `ItemsSource`
* `ButtonDistanceMode`, either `IndividualDistance` or `TotalDistance`

`ItemsSource` can be bound to an `IEnumerable` of the `DataContext` if you wish to populate the control programatically.

`RotateContents` will align the label to the direction of its button if set to `true`.

![RotateContents](/img/rotation.png)

### ButtonRingItem
An actual button instance. Its most relevant properties are:

* `Content`, to set the button text
* `Tooltip`
* `Command`, to handle the button click.

## Samples

The sample project demostrates how to add buttons programatically. It also demonstrates how the properties affect the appearance.

You can also add buttons at design time via XAML.
```xml
<wpfButtonRings:ButtonRing
    ControlSize="200"
    RingDistance="10"
    RingWidth="20"
    RingRotation="0"
    ButtonDistance="40"
    ButtonDistanceMode="TotalDistance"
    RotateContents="True">
    <wpfButtonRings:ButtonRingItem
        Content="One"
        Command="{Binding CommandOne}"/>
    <wpfButtonRings:ButtonRingItem
        Content="Two"
        Command="{Binding CommandTwo}" />
    <wpfButtonRings:ButtonRingItem
        Content="Three"
        Command="{Binding CommandThree}" />
</wpfButtonRings:ButtonRing>
```

## Limitations

At least 2 buttons are required. A single circular button is now supported.

