   M S B A M L   `   `   `  ����  MaritimeSecurityMonitoring2    ,MaritimeSecurityMonitoring.SituationPlayback   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  态势回放��5   	   $	��500��6   $	��500��6"   $	��500��61   $	��400��6@   $	��400��6M   $	��400��6]    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�6O    � 	Resources 5         CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value��%m  &	        &	 �     �� 5   
   " ��6.   .R�5	      �� $��0q�6   $ 8,8,0,0��6)   ���	#FF4A79D8._�5
      �� #��z��6#   $
��Left=�6V   $��Center=�6q   $��10 0 0 0q�6�   5      5      �� 5   
   " ��6/   .R�5      �� $ bd��6   $��0q�6!   $ 5 5 5 5��65   ���	#FF4A79D8._�5      �� #��z��6#   $��Center=�6V   $��Center=�6s   5       5      P� 5      	 �@J�IsMouseOver
 . . �5      �� $ bd��6    � �� �	#FF6D9DFF6C   5      P� 5      	 � ��
 . . �5      �� $ bd��6    � �� �	#FF005AE26C   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5!   
   �� #��[  6   $��20(�68   
�������.��6Y   态势回放6_   �� 5"   
   -   5        $��22��5"      $��22��6   $��0 0 10 0q�6(   $��Right=�6:   $��0q�6V   .��5#      �� $��Image/Close_new.png��6   ��5$      �� 5%       �� Color$ 	#FF4A79D8��6"   5'      �� 5)   
   $��1��6   $��0q�6   
�������$ 0 0 8 8��6E   ._�5*      �  5+      �� 5,      $
��3.2* �6$   �� 5-      $��* �6$   .+�50      �� $��0��6   $��1q�6&   
�������$ 8��6M   $��50 40q�6^   ._�51      �  52      �� 53      $��0.45* �6,   �� 54      $��* �6,   �� 55      $��* �6,   �� 56      $
��0.5* �6,    � ColumnDefinitions 58      �� 59      $��* �6/   �� 5:      $
��1.6* �6/   .+�5=      �� $��1��6$   $��0��61   $��20(�6A   $��Center=�6O   $��Center=�6j   $��15 0 0 0q�6�   开始时间6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5>      -   5        $��startTimeText��5?   �   $��1��5>   ,   $��1��69   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ShowButtonSpinner .  ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .     MouseWheelActiveOnFocus . $��16(�5?   ,   $��Center=�6:   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�6U      FormatString$ yyyy/MM/dd HH:mm:ss��6e      
TimeFormat$ LongTime=�6�   $��0 0 50 0q�6�   6�   �� 5A      $��2��6$   $��0��61   $��20(�6A   $��Center=�6O   $��Center=�6j   $��15 0 0 0q�6�   结束时间6�     5B      -   5        $��endTimeText��5C   �   $��2��5B   ,   $��1��69    .   .   . $��16(�5C   ,   $��Center=�6:   $ Custom=�6U   $ yyyy/MM/dd HH:mm:ss��6e   $ LongTime=�6�   $��0 0 50 0q�6�   6�   5D      5E      � 5G      $��1��6    5H      �� 5I      $��* �6+   �� 5J      $
��Auto �6+   �� 5K      $
��Auto �6+   �� 5L      $��* �6+   .+�5O      �� -   5        $��1��5O      #��[ 6-   $��40��6V   $	��100��6b   $��20(�6n   
�������$	��Top=�6�   $��0 0 80 0q�6�   .��6�   确定6�   �� 5P      -   5        $��2��5P      #��[ 6-   $��40��6V   $	��100��6b   $��20(�6n   
�������$	��Top=�6�   .��6�   取消6�   5Q      5R      5S      5T      5U      