   M S B A M L   `   `   `  ����G  CSiliconWafer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SiliconWaferSiliconWafer  5   	       SiliconWafer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SiliconWafer     5   	   Y UOxyPlot.Wpf.Shared, Version=2.1.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0R NOxyPlot.Wpf, Version=2.1.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0"oxyhttp://oxyplot.org/wpf   5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
MainWindow��5
   	   $	��800��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Number of Points��6   $��Center=�6+   $��346,10,334,54q�6H   $	��112��6_   6m   �� 5   
   -   5        $��	userInput��5   >   $��0��6   $��325,51,320,20q�6O    �� 	MaxLength$ 3��6f    �� TextAlignment$ Center=�6t   �� 5   
   -   5        $��okButton��5   +   $��1��6   $��OK��6   $��50��6L   $	��100��6X   6g   � 5   
   -   5        $��renderSpace��5      $��2��6   $��106,0,93,-449q�6/   $	��600��6F   $	��500��6R   .+�5        OxyPlot.Wpf.PlotView  -   5        $��PV��5      $��	20,0,38,0q�6?     OxyPlot.Wpf.PlotViewBase   Model 6&   �� *Model0+6?   5      5      5      