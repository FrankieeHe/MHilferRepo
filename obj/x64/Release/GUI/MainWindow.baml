   M S B A M L   `   `   `  ���� E  AWpfMHilfer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfMHilfer.GUIWpfMHilfer.GUI  1clr-namespace:WpfMHilfer.viewWpfMHilfer.view  H DShowMeTheXAML, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAMLShowMeTheXAML c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity ;"clr-namespace:WpfMHilfer.converterWpfMHilfer.converter      WpfMHilfer.GUI.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:WpfMHilfer.GUI     .viewclr-namespace:WpfMHilfer.view     V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  =smtx2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML  XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  2	converter"clr-namespace:WpfMHilfer.converter    � Title$  
MainWindow�� � 	Resources  �� MergedDictionaries �� Source(  "WpfMHilfer.converter.BoolConverter   boolConverter)  #WpfMHilfer.converter.ColorConverter  colorConverter.  (WpfMHilfer.converter.VisibilityConverter  visibilityConverter.  (WpfMHilfer.converter.PercentageConverter  PercentageConverter��  �� $d ^pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml?��� $ styles.xaml?��� $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?��� $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?��� $y spack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.LightBlue.xaml?��� $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Blue.xaml?�%<   &	        &	      &	 
     &	              .��� -    �Name$ 	MainPanel�� � ColumnDefinitions �� $��* ��� $��2* �.+���  �� CornerRadius$ 5��
�������$��2q�$��0��$��2��._�]� -    ]�Name$ MenuDockPanel����.  .+�]� $	��Top=�.+�� -   $ 
HeaderGrid�� �� $��* ��� $��4.85* ��� $��3* �.+��� -    ��Name$
 Home��$��0��$
��Left=����� 	 �� 	Converter#	 [ 
 �� ElementName$
 
HeaderGrid�� �� Path$ ActualWidth� �� ConverterParameter$	 0.1������ .R��� $��/resources/home.png�� J� InputBindings d�  d� Gesture$ 	LeftClicka� �� Command �� *HomeButtonCommand+ �� CommandParameter ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ ButtonL� �� AncestorLevel$ 1����  �� Orientation$ 
Horizontal=�$��1��.+��� -   $ Return��$��Return��$��1��$
��Left=�$��Center=�$
��Auto��$
��Left=�
 � Tag �� *ParentElement+ d� $ 	LeftClicka� �� *ReturenButtonCommand+ ��  �� $ FindAncestor=�$ ButtonL�$ 1���� -   $
 Next��$
��Next��$��1��$
��Auto��$��Center=� d� $ 	LeftClicka� �� *NextButtonCommand+ ��  �� $ FindAncestor=�$ ButtonL�$ 1���� -    ��Name$ ParentLabel��$��2������ $ ParentElement.name�� $��Bottom=�$
��Auto�� �� $��* ��� $��2* �.+��� -   $	 Add��$	��ADD��$��1��$��Right=�$��0,0,3,0q�$��Center=� + 'MaterialDesignFloatingActionLightButton#���  �� $��0��$��Center=�.+��� -	   $
��Load���� -
   $
��Save���� -    ��Name$ TableStackPanel��$y�Visible=�$��Stretch=� J� RenderTransformOrigin$ 0.5,0.5&� � DataContext �� $ ListView� �� Mode$ TwoWay=����� *ActualWidth+$
 MenuDockPanel��z�V� .~��� �� ��  �� Angle$ 0.254Q�T� .+��� -    ��Name$ NamesListView������ *Names+���� .R��� .+��� $��Center=�$��Center=� �� 	IsEnabled .   �� ShowOnDisabled . ���� ���� #	 [ $
 TableStackPanel��$ ActualWidth�$
 0.92�� �� $
 	MainPanel�� d� $ LeftDoubleClicka� �� $$ DataContext.DoubleClickCommand�$
 	MainPanel�� �� d� $ 	LeftClicka� �� *DataContext.OneClickCommand+$
 	MainPanel�� �� d� $ 
RightClicka� �� *DataContext.RightClickCommand+$
 	MainPanel�� ��  �� $ FindAncestor=�$ ButtonL�$ 1��  � ContextMenu  �� .@�m� $��Shift��! m� Command! �� $2 ,PlacementTarget.Tag.DataContext.ShiftCommand� �� $ ContextMenuL�" m� CommandParameter" �� $ PlacementTarget� �� $ ContextMenuL�m� $��Delete��! �� $3 -PlacementTarget.Tag.DataContext.DeleteCommand� �� $ ContextMenuL�" �� $ PlacementTarget� �� $ ContextMenuL�� -   $ DescriptionPanel��$��1��$	��Top=�# � RowDefinitions# �� $��* ��� $
��Auto ��� $
��Auto �.+�(  "System.Windows.Controls.WebBrowser  -   $��DescWebBrowser��$��0��$��Stretch=�$��Center=�&    WpfMHilfer.view.WebBrowserHelper$   Body$ �� *Description+$ TwoWay=�
%   Url% �� *	DescUrl+$ TwoWay=��� -   $��SeeAlsoTextBlock��$��	See Also:��$��1��$��	30,0,0,30q� % !MaterialDesignSubheadingTextBlock#��[ $
��Left=�$��26��$��Bottom=�y��� #	 [ $
 SeeAlsoListView��$ Items.Count�$ 1���� -   $ SeeAlsoListView��
������ $��2��$��	30,0,0,30q�$
��Left=�$	��118������ #	 [ $
 DescriptionPanel��$ ActualWidth�$	 0.5������ *SeeAlsoListView.Names+���� .R��� .+���   LinkButtonStyle#��[ $
��Auto������ ���� #	 [ $
 SeeAlsoListView��$ ActualWidth�$
 0.92������ $$ DataContext.SeeAlsoJumpCommand�$
 	MainPanel������ � -   $��
SearchGrid��$��1��$��Bottom=�$��Center=����� #	 [ $
 DescriptionPanel��$ ActualWidth�$	 0.6�� �� $��* ��� $
��Auto �.+��� -   $��	SearchBox��$��0��$
��Left=�$��Bottom=�$	��2pxq�& �� TextWrapping$
& Wrap=�$��35��$��Center=����� #	 [ $
 
SearchGrid��$ ActualWidth�$
 0.86������ *DataContext.SearchText+$ TwoWay=�$
 
SearchGrid��.����O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem �� 0sys&clr-namespace:System;assembly=mscorlib  ' �� 
TargetType"' ��( �� 	Resources(   CueBannerBrush) j� 
AlignmentX* j� 
AlignmentY+ j� Stretch, !� Visual��%`   &	       !� $
) Left=�$* Center=�$
+ None=�, �� $��Search��
�������$��Italic$�- �� Triggers- P� . P� Property. � ��/ �� Empty0 P� Value#0 Z/ . ��� 1 �� Property1 � ��2 �� Value#2 [ P� . � ��0 Z� . ��� 1 � ��#2 [ P� . �@J�IsKeyboardFocused0 . . ��� 1 � ��
2 �����.�� �� 
3 �� Key$3 Enter�� �� *SearchTextBoxEnterCommand+$ OneWay=� �� $
 	SearchBox��.��.  (System.Windows.Interactivity.Interaction4   Triggers4 /  )System.Windows.Interactivity.EventTrigger  5   	EventName$5 GotFocus��.	  (System.Windows.Interactivity.TriggerBase6 	  Actions.6 6
  0System.Windows.Interactivity.InvokeCommandAction
  7 
  Command7 �� *SearchBox_GotFocus+$ OneWay=�8 
  CommandParameter8 �� $
 	SearchBox��  $5 GotMouseCapture��.6 
  7 �� *SearchTextBox_GotMouseCapture+$ OneWay=�8 �� $
 	SearchBox��.���� $��1��  NoChromeButton#���  $��40������ *SearchButtonCommand+���� $
 	SearchBox������ .R��� $��/resources/search.png���� -   $ 
EditButton��$
��Edit��$��Right=�$��Bottom=�$��0,0,0,0q�#��[ $��1�� d� $ 	LeftClicka�$  �� �� *EditButtonCommand+