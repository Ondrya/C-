Bad practice : put loading data to constructor

Better : invoke loading as a command after window loading event

##How:##

1) in XAML

```
    <i:Interaction.Triggers>
        <i:EventTrigger EventName="Loaded">
            <i:InvokeCommandAction Command="{Binding LoadDataCommand}"/>
        </i:EventTrigger>
    </i:Interaction.Triggers>
```
    
2) in command invoke loading method
