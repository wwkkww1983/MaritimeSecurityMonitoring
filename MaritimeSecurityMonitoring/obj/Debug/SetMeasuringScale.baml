   M S B A M L   `   `   `  ����U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  5   	   8    2MaritimeSecurityMonitoring.Video.SetMeasuringScale   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6m(clr-namespace:MaritimeSecurityMonitoring     5   	   -   5          � Title$  指定比例尺��5   	   $	��400��6   $	��400��6#   $	��400��62   $	��420��6A   $	��420��6N   $	��420��6^    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�6O    � 	Resources 5         CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  TextBoxErrorTemp �� 
TargetType �� Triggers �� ElementName �� Path 
 Cancel��%�  &	        &	 �     &	 Y    &	 M    �� 5   
   " ��6.   .R�5	      �� $��0q�6   $ 8,8,0,0��6)   ���	#FF4A79D8._�5
      �� #��z��6#   $
��Left=�6V   $��Center=�6q   $��10 0 0 0q�6�   5      5      �� 5   
   " ��6/   .R�5      �� $ bd��6   $��0q�6!   $ 5 5 5 5��65   ���	#FF4A79D8._�5      �� #��z��6#   $��Center=�6V   $��Center=�6s   5       5      P� 5      	 �@J�IsMouseOver
 . . �5      �� $ bd��6    � �� �	#FF6D9DFF6C   5      P� 5      	 � ��
 . . �5      �� $ bd��6    � �� �	#FF005AE26C   5      5      �� 5   
   " ��6)    5      P� 5      	 �@=�HasError
 . . �5      ��  �@=�ErrorTemplate 5      �� 5       .R�5!   "   ]� ��. .+�5"   &   �� $��Bottom=�60   
���  ��$��16(�6Y   $
��Bold"�6g   $��Center=�6y   ��6�   �� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5#   '   �� 5$   &   
���  ��$��2q�6?   $	��164��6S   ._�5%   *   �� $��	MyAdorner��6D   5&   '   5'   #   5(      5*      5+      5-      �� 5.   
   6   5/       J� InputBindings 50      �� 51   
   
 �� Key$	 Esc��6    �� Command# [ 6    J� CommandBindings 53      )  #System.Windows.Input.CommandBinding  54   
   -   5           Command# [ 54      6b   .��57      �  � RowDefinitions 58   
   �� 59      $��40 �6   �� 5:      $��* �6   .+�5=   
   �� #��[  6   $��20(�68   
�������.��6Y   指定比例尺6`   �� 5>   
   -   5        $��22��5>      $��22��6   $��0 0 10 0q�6(   $��Right=�6:   $��0q�6V   .��5?      �� $��Image/Close_new.png��6   ��5@      �� 5A       �� Color$ 	#FF4A79D8��6"   5C      �� 5E   
   $��1��6   $��0q�6   
�������$ 0 0 8 8��6E   ._�5F      �  5G      �� 5H      $��4* �6$   �� 5I      $��* �6$   .+�5L      �� $��0��6   $��1q�6&   
�������$ 8��6M   $��40 35 40 25q�6^   ._�5M      �  5N      �� 5O      $
��0.3* �6,   �� 5P      $��* �6,   �� 5Q      $��* �6,   �� 5R      $��* �6,   �� 5S      $
��0.6* �6,   �� 5T      $��* �6,   �� 5U      $
��0.5* �6,   .+�5X      	� -   5         	�Name$
 rad1��5X   3   $��1��6&   $��20(�6A   $��Center=�6O   $��Center=�6j    d� 	IsChecked$
 TrueY�6�   $��62 0 0 0q�6�   .��6�   选择比例尺：6�   � 5Y      $��2��6$   $��Center=�61   $��Center=�6L   .+�5Z      �� $��20(�6(   $��Center=�66   1：6U   �� 5[      -   5         ��Name$	 com��5[   c   $	��160��6'   $��20(�63   $��Center=�6A   {�. .@�5\   "   �� .��6/   162   �� 5]   "   .��6/   1063   �� 5^   "   .��6/   10064   �� 5_   "   .��60   50065   �� 5`   "   .��6/   100065   �� 5a   "    �� 
IsSelected . .��6A   50006G   �� 5b   "   .��60   1000067   �� 5c   "   .��6/   5000066   �� 5d   "   .��6/   10000067   �� 5e   "   .��6/   50000067   �� 5f   "   .��6/   	100000068   �� 5g   "   .��6/   	500000068   �� 5h   "   .��6/   
1000000069   �� 5i   "   .��6/   
5000000069   �� 5j   "   .��6/   	1000000006:   5k      5l      	� 5n      -   5        $��3��5n   &   $��20(�63   $��Bottom=�6A   $��Center=�6\   $��62 0 0 5q�6�   .��6�   指定比例尺：6�   �� 5o      $��4��6$   $��16(�61   $��Center=�6?   $��62 0 0 0q�6Z   （< 2147483648）6   � 5p      $��5��6$   $��Center=�61   $��Center=�6L   .+�5q      �� $��20(�6(   $��Center=�66   1：6U   �� 5r      -   5         ��Name$ test1��5r   �   #��[ 6&   $	��160��6P   $��20(�6\   $��Center=�6j   {�.  .��6�   ��5s   "   �� 5t   &   $ value�6.    �� Mode$ TwoWay=�6;    �� UpdateSourceTrigger$ PropertyChanged=�6I     �� NotifyOnValidationError  . ! �� ValidationRules! 5u   *   ;   5MaritimeSecurityMonitoring.NumberValidationRuleForInt  5v   .   -   5        rule��
"   Min$" 1��5v   Y   
#   Max$# 
2147483647��6a   6t   5x   '   .��5y   0   5z      5{      5|      5}      � 5      $��1��6   $ � ColumnDefinitions$ 5�      �� 5�      $��* �6+   �� 5�      $
��Auto �6+   �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� -	   5        $��1��5�      #��[ 6-   $��35��6h   $��90��6t   $��20(�6   
�������$	��Top=�6�   $��0 0 70 0q�6�   .��6�   确定6�   �� 5�      -
   5        $��2��5�      #��[ 6-   $��35��6j   $��90��6v   $��20(�6�   
�������$	��Top=�6�   .��6�   取消6�   5�      5�      5�      5�      5�      