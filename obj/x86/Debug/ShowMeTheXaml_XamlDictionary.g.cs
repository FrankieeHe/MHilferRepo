
using System.Collections.Generic;

namespace ShowMeTheXAML
{
    public static class XamlDictionary
    {
        static XamlDictionary()
        {
            XamlResolver.Set("cards_3", @"<smtx:XamlDisplay Key=""cards_3"" Margin=""4 4 0 0"" VerticalContentAlignment=""Top"" xmlns:smtx=""clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML"">
  <materialDesign:Card Foreground=""{DynamicResource PrimaryHueDarkForegroundBrush}"" Padding=""0"" Width=""200"" xmlns:materialDesign=""http://materialdesigninxaml.net/winfx/xaml/themes"">
    <Grid xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
      <Grid.RowDefinitions>
        <RowDefinition Height=""Auto"" />
        <RowDefinition Height=""Auto"" />
        <RowDefinition Height=""Auto"" />
      </Grid.RowDefinitions>
      <TextBlock Grid.Row=""0"" Margin=""16 16 16 4"" Background=""#03a9f4"" FontSize=""14"" Style=""{StaticResource MaterialDesignHeadlineTextBlock}"">Call Jennifer</TextBlock>
      <Separator Grid.Row=""1"" Style=""{StaticResource MaterialDesignLightSeparator}"" />
      <TextBlock Grid.Row=""2"" Margin=""16 0 16 8"" VerticalAlignment=""Center"" HorizontalAlignment=""Left"" Style=""{StaticResource MaterialDesignBody2TextBlock}"">March 19, 2016</TextBlock>
      <StackPanel Grid.Row=""2"" Orientation=""Horizontal"" Margin=""16 0 16 8"" HorizontalAlignment=""Right"">
        <Button HorizontalAlignment=""Right"" Style=""{StaticResource MaterialDesignToolForegroundButton}"" Width=""30"" Padding=""2 0 2 0"" materialDesign:RippleAssist.IsCentered=""True"">
          <materialDesign:PackIcon Kind=""OpenInNew"" />
        </Button>
        <materialDesign:PopupBox HorizontalAlignment=""Right"" Style=""{StaticResource MaterialDesignToolForegroundPopupBox}"" Padding=""2 0 2 0"">
          <StackPanel>
            <Button Content=""More"" />
            <Button Content=""Options"" />
          </StackPanel>
        </materialDesign:PopupBox>
      </StackPanel>
    </Grid>
  </materialDesign:Card>
</smtx:XamlDisplay>");
XamlResolver.Set("feedback", @"<smtx:XamlDisplay Grid.Row=""2"" Key=""feedback"" VerticalAlignment=""Bottom"" Grid.ColumnSpan=""2"" Height=""44"" xmlns:smtx=""clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML"">
  <StackPanel HorizontalAlignment=""Right"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
    <TextBlock Style=""{StaticResource MaterialDesignBody2TextBlock}""> Do you like it?</TextBlock>
    <Viewbox Margin=""0 4 0 8"" Height=""16"" HorizontalAlignment=""Left"" VerticalAlignment=""Bottom"">
      <materialDesign:RatingBar Value=""4"" Orientation=""Horizontal"" Foreground=""Gold"" Margin=""0"" xmlns:materialDesign=""http://materialdesigninxaml.net/winfx/xaml/themes"" />
    </Viewbox>
  </StackPanel>
</smtx:XamlDisplay>");
        }
    }
}