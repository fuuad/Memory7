   M S B A M L   `   `   `  ����A  =Memory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MemoryMemory  5   	       Memory.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Memory     5   	     � Title$  Memory��5   	   $	��450��6   $	��800��6%   $	��450��61   $	��800��6A   $��20(�6P   .��5
      � ��5   
   �� 5       �� Color$
 blue��6    �� Opacity$	 0.3Q�6+   .+�5   
   � -   5         �Name$ 
parentGrid��5       � ColumnDefinitions 5      �� 5      $��5* �6#   �� 5      $��2* �6#   .+�5      � -   5        $ GameGrid��5      5      (� 5      $��1��6   $��0q�6&   .��5      �� -   5         ��Name$ 
scoreBoard��5      
�������$	��120��6H   $	��280��6T   $y�	Collapsed=�6a   .+�5      �� 
�������$��10q�67   .+�5      �� $��Center=�6    
�������$
��Tijd��6Z   $��80��6i   �� 5      -   5         ��Name$ 
TimerLabel��5       $��Center=�64   
�������$��00:00��6n   $��80��6~   5      �� 5       
�������$��10q�67   .+�5!      �� -   5        $ Player1Label��5!       $��Center=�66   $��Speler1��6Z   $��80��6l   �� 5"      -   5        $ Score1Label��5"   !   $��Center=�66   $��0��6Z   $��80��6f   5#      �� 5%      -   5        $ SinglePlayer��5%   !   
�������$��10q�6M   $y�	Collapsed=�6Y   .+�5&      �� -   5        $ Player2Label��5&       $��Center=�66   $��Speler2��6Z   $��80��6l   �� 5'      -	   5        $ Score2Label��5'   !   $��Center=�66   $��0��6Z   $��80��6f   5(      5)      5*      5+       � 5-   
   -
   5          �Name$ 	MainFrame��5-        � NavigationUIVisibility$ Hidden=�6#   ��6C   �� *CurrentPage+	 �� 	Converter	 )   #Memory.ApplicatiePageValueConverter  5.      5/      