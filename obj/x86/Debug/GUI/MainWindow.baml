   M S B A M L   `   `   `  ����E  AWpfMHilfer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfMHilfer.GUIWpfMHilfer.GUI  5   	   1clr-namespace:WpfMHilfer.viewWpfMHilfer.view  5   	   H DShowMeTheXAML, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAMLShowMeTheXAML 5	   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
   	   ;"clr-namespace:WpfMHilfer.converterWpfMHilfer.converter  5   	       WpfMHilfer.GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfMHilfer.GUI     5   	   .viewclr-namespace:WpfMHilfer.view     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   =smtx2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML  5	   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5
   	   2	converter"clr-namespace:WpfMHilfer.converter  5   	     � Title$  
MainWindow��5   	    � 	Resources 5       �� MergedDictionaries �� Source(  "WpfMHilfer.converter.BoolConverter   boolConverter)  #WpfMHilfer.converter.ColorConverter  colorConverter.  (WpfMHilfer.converter.VisibilityConverter  visibilityConverter.  (WpfMHilfer.converter.PercentageConverter  PercentageConverter�� 5   
    5      �� 5      $d ^pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml?�6%   �� 5      $ styles.xaml?�6%   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $y spack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.LightBlue.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Blue.xaml?�6%   %t   &	        &	      &	 &     &	 9       5      6&     5      6'     5      6,     5      6,   5      .��5!      � -   5         �Name$ 	MainPanel��5!       � ColumnDefinitions 5#   
   �� 5$      $��* �6   �� 5%      $��2* �6   .+�5'   
   ��  �� CornerRadius$ 5��6   
�������$��2q�66   $��0��6J   $��2��6Z   ._�5(      ]� -   5         ]�Name$ MenuDockPanel��5(      ��.  .+�5)      ]� $	��Top=�6   .+�5*      � -   5        $ 
HeaderGrid��5*       5+      �� 5,      $��* �6/   �� 5-      $��4.85* �6/   �� 5.      $��3* �6/   .+�50      �� -   5         ��Name$
 Home��50   !   $��0��6/   $
��Left=�51   !   ��52   !   �� 	 �� 	Converter#	 [ 
 �� ElementName$
 
HeaderGrid�� �� Path$ ActualWidth� �� ConverterParameter$	 0.1����57      �� 58   "   .R�59   &   �� $��/resources/home.png��6,   5:   #    J� InputBindings 5<      d� 5=   "    d� Gesture$ 	LeftClicka�6/    �� Command 6C   �� *HomeButtonCommand+ �� CommandParameter 6i   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ ButtonL� �� AncestorLevel$ 1��5?      �� 5@       �� Orientation$ 
Horizontal=�6%   $��1��6>   .+�5B      �� -   5        $ Return��5B   !   $��Return��61   $��1��6C   $
��Left=�5C   !   $��Center=�5E   !   $
��Auto��5F   !   $
��Left=�5G   !   
 � Tag 5D   !   �� *ParentElement+ 5H      d� 5I   "   $ 	LeftClicka�6/    6C   �� *ReturenButtonCommand+ 6l   ��  �� $ FindAncestor=�$ ButtonL�$ 1��5K      �� 5L      -   5        $
 Next��5L   !   $
��Next��6/   $��1��6>   $
��Auto��5M   !   $��Center=�5N   !    5O      d� 5P   "   $ 	LeftClicka�6/    6C   �� *NextButtonCommand+ 6i   ��  �� $ FindAncestor=�$ ButtonL�$ 1��5R      5S      �� 5T      -   5         ��Name$ ParentLabel��5T       $��2��5U      ��5T   5   �� $ ParentElement.name�5U      5V      5W      � 5Y      $��Bottom=�6   $
��Auto��6/    5Z      �� 5[      $��* �6+   �� 5\      $��2* �6+   .+�5^      �� -   5        $	 Add��5^      $	��ADD��6*   $��1��68   $��Right=�6H   $��0,0,3,0q�6d   $��Center=�6v    + 'MaterialDesignFloatingActionLightButton#���  5`      6a   �� 5a      $��0��6!   $��Center=�61   .+�5b      �� -	   5        $
��Load��5b   !   6D   �� 5c      -
   5        $
��Save��5c   !   6D   5d      5e      �� 5g      -   5         ��Name$ TableStackPanel��5g      $y�Visible=�67   $��Stretch=�5h       J� RenderTransformOrigin$ 0.5,0.5&�5j   W    � DataContext 5i      �� $ ListView� �� Mode$ TwoWay=���5j      �� *ActualWidth+$
 MenuDockPanel��z�5k      V� 5l      .~�5m      �� �� 5n      �� 5o       �� Angle$ 0.254Q�6.   T� 5p      5q      .+�5s      �� -   5         ��Name$ NamesListView��5s      ��67   �� *Names+��5t      �� 5u      .R�5v   "   �� .+�5w   &   �� $��Center=�5}   -   $��Center=�5~   -    �� 	IsEnabled .   �� ShowOnDisabled . ��5w   -   �� ��5x   -   �� #	 [ $
 TableStackPanel��$ ActualWidth�$
 0.92�� 5�   -   �� $
 	MainPanel�� 5�   *   d� 5�   .   $ LeftDoubleClicka�6;    6U   �� $$ DataContext.DoubleClickCommand�$
 	MainPanel�� 5�   ;   �� d� 5�   .   $ 	LeftClicka�6;    6O   �� *DataContext.OneClickCommand+$
 	MainPanel�� 5�   ;   �� d� 5�   .   $ 
RightClicka�6;    6P   �� *DataContext.RightClickCommand+$
 	MainPanel�� 5�   ;   ��  �� $ FindAncestor=�$ ButtonL�$ 1��5�   /     � ContextMenu  5�   *   �� 5�   .   .@�5�   2   m� $��Delete��6;   ! m� Command! 5�   ;   �� $3 -PlacementTarget.Tag.DataContext.DeleteCommand� �� $ ContextMenuL�" m� CommandParameter" 5�   ;   �� $ PlacementTarget� �� $ ContextMenuL�5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      � 5�   
   -   5        $ DescriptionPanel��5�      $��1��6)   $	��Top=�69   # � RowDefinitions# 5�      �� 5�      $��* �6    6-   �� 5�      $
��Auto �6    60   �� 5�      $
��Auto �6    60   .+�5�      (  "System.Windows.Controls.WebBrowser  -   5        $��DescWebBrowser��5�      $��0��5�      $��Stretch=�5�      $��Center=�5�      &    WpfMHilfer.view.WebBrowserHelper$   Body$ 5�      �� *Description+$ TwoWay=�
%   Url% 5�      �� *	DescUrl+$ TwoWay=�5�      �� 5�      -   5        $��SeeAlsoTextBlock��5�      $��	See Also:��60   $��1��6B   $��	30,0,0,30q�6O    % !MaterialDesignSubheadingTextBlock#��[ 5�      $
��Left=�6S   $��26��6n   $��Bottom=�6z   y�5�      �� #	 [ $
 SeeAlsoListView��$ Items.Count�$ 1���� 5�      -   5        $ SeeAlsoListView��5�      
������ $��2��6J   $��	30,0,0,30q�6W   $
��Left=�6j   $	��118��5�   E   ��5�      �� #	 [ $
 DescriptionPanel��$ ActualWidth�$	 0.5����5�      �� *SeeAlsoListView.Names+��5�      �� 5�      .R�5�      �� .+�5�      ��   LinkButtonStyle#��[ 6:   $
��Auto��5�   �   ��5�   %   �� ��5�   %   �� #	 [ $
 SeeAlsoListView��$ ActualWidth�$
 0.92����5�   %   �� $$ DataContext.SeeAlsoJumpCommand�$
 	MainPanel����5�   %   �� 5�      5�      5�      5�      � 5�   
   -   5        $��
SearchGrid��5�      $��1��6!   $��Bottom=�62   $��Center=�6M   ��5�      �� #	 [ $
 DescriptionPanel��$ ActualWidth�$	 0.6�� 5�      �� 5�      $��* �6#   �� 5�      $
��Auto �6#   .+�5�      �� -   5        $��	SearchBox��5�      $��0��6(   $
��Left=�69   $��Bottom=�6T   $	��2pxq�5�      & �� TextWrapping$
& Wrap=�5�      $��35��6/   $��Center=�5�   g   ��5�   ;   �� #	 [ $
 
SearchGrid��$ ActualWidth�$
 0.86����5�      �� *DataContext.SearchText+$ TwoWay=�$
 
SearchGrid��.��6�   ��5�      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5�   1   �� 6   0sys&clr-namespace:System;assembly=mscorlib  61   ' �� 
TargetType"' ��6   ( �� 	Resources( 5�        CueBannerBrush) j� 
AlignmentX* j� 
AlignmentY+ j� Stretch, !� Visual��%�   &	       !� 5�      $
) Left=�6A   $* Center=�6S   $
+ None=�6g   , 5�   "   �� 5�   &   $��Search��6,   
�������$��Italic$�6T   6i   5�      5�      - �� Triggers- 5�      P� 5�      . P� Property. � ��/ �� Empty0 P� Value#0 Z/ 66   . �5�   "   �� 1 �� Property1 � ��2 �� Value#2 [ 6?   6i   5�      P� 5�      . � ��0 66   Z� . �5�   "   �� 1 � ��#2 [ 6?   6i   5�      P� 5�      . �@J�IsKeyboardFocused0 . . �5�   "   �� 1 � ��
2 �����6O   5�      5�      .��5�   !    5�      �� 5�      
3 �� Key$3 Enter��6!    6-   �� *SearchTextBoxEnterCommand+$ OneWay=� 6h   �� $
 	SearchBox��.��5�   )   .  (System.Windows.Interactivity.Interaction4   Triggers4 5�      /  )System.Windows.Interactivity.EventTrigger  5�      5   	EventName$5 GotFocus��6%   .	  (System.Windows.Interactivity.TriggerBase6 	  Actions.6 5�      6
  0System.Windows.Interactivity.InvokeCommandAction
  7 
  Command7 60   �� *SearchBox_GotFocus+$ OneWay=�8 
  CommandParameter8 6e   �� $
 	SearchBox��5�        5�      $5 GotMouseCapture��6%   .6 5�      
  7 60   �� *SearchTextBox_GotMouseCapture+$ OneWay=�8 6p   �� $
 	SearchBox��5�      .��5�   *   5�      �� 5�      $��1��6     NoChromeButton#���  6%   $��40��5�      ��6$   �� *SearchButtonCommand+��5�      �� $
 	SearchBox����5�      �� 5�      .R�5�      �� $��/resources/search.png��6    5�      5�      5�      �� 5�   
   -   5        $ 
EditButton��5�      $
��Edit��6%   $��Right=�64   $��Bottom=�6P   $��0,0,0,0q�6k   #��[ 6|   $��1��6�    5�      d� 5�      $ 	LeftClicka�6   $  ��6Y    63   �� *EditButtonCommand+5�      5�      5�      5      