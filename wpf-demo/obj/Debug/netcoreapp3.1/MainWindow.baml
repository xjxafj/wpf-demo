   M S B A M L   `   `   `  ����C  ?wpf-demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:wpf_demowpf_demo  5   	       wpf_demo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:wpf_demo     5   	   G CHandyControl, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null0hc'https://handyorg.github.io/handycontrol  5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 65   �� *MainWindowViewModel+   Locator �� Source# [  .��5
      �� .+�5   
   )  #HandyControl.Controls.NumericUpDown     Value 6   �� *Age+  LevelConverter �� 	Converter# [ 6]   #  HandyControl.Controls.TextBox  5   
   -   5          Name$ SelectPrintTaskName��5      $
��Left=�62      ShowClearButton$ False��6M    �� 
IsReadOnly$
 True��6e   $	��280��6w   $��30��6�   (  "HandyControl.Controls.TitleElement   
TitleWidth$ 70 �6�   '  !HandyControl.Controls.InfoElement	   Placeholder$	 请选择一个任务��6�   
   TitlePlacement$

 Left=�6�      Title$ 任务名称��6�      	Necessary$
 True��6  $��0,0,0,0q�64  � 5   
    � Minimum$ 0Q�6    � Maximum$	 100Q�6"    � Value 60   �� *ProcessValue+6Q   �� 5   
   -   5        
 � Tag$
 stop��5   &   .��61   停止65   �� 5   
   -   5        $
 wait��5   &   .��61   暂停65   5      5      