   M S B A M L   `   `   `  ����H  DShowMeTheXAML, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAMLShowMeTheXAML  5   	   E AWpfMHilfer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfMHilfer.GUIWpfMHilfer.GUI 5   	   ;"clr-namespace:WpfMHilfer.viewmodelWpfMHilfer.viewmodel 5	   	   1clr-namespace:WpfMHilfer.viewWpfMHilfer.view 5
   	   '   !WpfMHilfer.GUI.SearchResultWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   =smtx2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML  5   	   (localclr-namespace:WpfMHilfer.GUI  5   	   2	viewmodel"clr-namespace:WpfMHilfer.viewmodel  5	   	   (viewclr-namespace:WpfMHilfer.view  5
   	      MaterialDesignBody#���   6F   $��Regular"�6�   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $y spack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.LightBlue.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Blue.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $d ^pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Card.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.CheckBox.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Flipper.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Popupbox.xaml?�6%   %    5      .��5!      � -   5        $��SearchResultGird��5!       � RowDefinitions 5#   
   �� 5$      $
��Auto �6   6,   �� 5%      $��* �6   6)   �� 5&      $
��Auto �6   6,   .+�5(   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   .+�5)      �� -   5         ��Name$ 
SearchItem��5*       % !MaterialDesignFloatingHintTextBox#��[ 5)      $��Center=�5+      $	��200��5,      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
new Search��5-      .��6B   	 J� InputBindings	 5.      �� 5/      

 �� Key$
 Enter��6!    �� Command 6-   �� *SearchResultButtonCommand+ �� Mode$ OneWay=� �� CommandParameter 6h   ��  �� Path$
 Text� �� ElementName$ 
SearchItem��.��50   )   51      �� 52       * &MaterialDesignFloatingActionDarkButton#��[ 6   $��Right=�55      $��
0,7,16,-20q�56      $
��Auto��6-   ��53      �� *SearchResultButtonCommand+��54      �� $
 Text�$ 
SearchItem��.��57      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ FileFind=�6*   58      59      �� 5<   
   -   5        $��SearchResultsListView��5<      $��1��61   ��5=      �� $' !searchResultsListView.NameAndDesc�$ TwoWay=���5>      �� 5?      .R�5@      �� .+�5A         ShowMeTheXAML.XamlDisplay  
   Key$ cards_3��6+   $��4 4 0 0q�69   $	��Top=�6J   .��5B      #  MaterialDesignThemes.Wpf.Card   ! PrimaryHueDarkForegroundBrush#���  5C      $��0q�5D      $	��400��5E      .��5F   "   �  5G   &   �� 5H   *   $
��Auto �68   �� 5I   *   $
��Auto �68   .+�5K   &   �� $��0��60   $��	16 4 16 2q�6=   ���#03a9f4$��14(�6e    # MaterialDesignHeadlineTextBlock#��[ 5L   0   ��5M   0   �� *Key+6G   �� 5N   &   $��1��60   $��	16 0 16 2q�6=   $��Center=�6P   $��12(�5O   0   
���   �$
��Left=�5P   0   #��[ 6K   ��5Q   0   �� *Value+�� 5R   &   $��1��61   $ 
Horizontal=�6>   $��	16 0 16 8q�6W   $��Right=�6j   .+�5S   *   �� $��Right=�61   $��Bottom=�6M    & "MaterialDesignToolForegroundButton#��[ 6h   $��30��5T   1   $��2 0 2 0q�6<   
���   �+  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .��5V   .     $ 	OpenInNew=�6F   	 5W   .   d� 5X   2    d� Gesture$ 	LeftClicka�6?    6S   �� $" DataContext.LeftClickCommand�$ SearchResultGird�� 5Y   ;   �� *Key+5[   +   5\   '   5]   #   5^      5_      5`      5b      5d        5l   
   $��2��6   $ feedback��6)   $��Bottom=�69   $��2��6T   $��44��6h   .��5n      �� $��Right=�6   .+�5o      ��    MaterialDesignBody2TextBlock#��[ 6   Do you like it?6f   (� 5p      $��0 4 0 8q�6   $��16��6,   $
��Left=�68   $��Bottom=�6S   .��5q      (  "MaterialDesignThemes.Wpf.RatingBar     Value$ 4��6/      Orientation$ 
Horizontal=�69   
��� ���$��0q�6d   5r      5s      5t      5u      5v      