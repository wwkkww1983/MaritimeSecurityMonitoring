   M S B A M L   `   `   `  ����  MaritimeSecurityMonitoring+    %MaritimeSecurityMonitoring.TrackEvent   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  跟踪事件��5   	   $	��450��6   $	��450��6#   $	��450��6/   $	��450��6?   $	��450��6N   $	��450��6^    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � AllowsTransparency . 
������  � 	Resources 5         CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value��%m  &	        &	 �     �� 5   
   " ��6.   .R�5      �� $��0q�6   $ 8,8,0,0��6)   ���	#FF4A79D8._�5	      �� #��z��6#   $
��Left=�6V   $��Center=�6q   $��10 0 0 0q�6�   5
      5      �� 5   
   " ��6/   .R�5      �� $ bd��6   $��0q�6!   $ 5 5 5 5��65   ���	#FF4A79D8._�5      �� #��z��6#   $��Center=�6V   $��Center=�6s   5       5      P� 5      	 �@J�IsMouseOver
 . . �5      �� $ bd��6    � �� �	#FF6D9DFF6C   5      P� 5      	 � ��
 . . �5      �� $ bd��6    � �� �	#FF005AE26C   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5    
   �� #��[  6   $��20(�68   
�������.��6Y   跟踪事件6_   �� 5!   
   -   5        $��22��5!      $��22��6   $��0 0 10 0q�6(   $��Right=�6:   $��0q�6V   .��5"      �� $��Image/Close_new.png��6   ��5#      �� 5$       �� Color$ 	#FF4A79D8��6"   5&      �� 5(   
   $��1��6   $��0q�6   
�������$ 0 0 8 8��6E   ._�5)      �  5*      �� 5+      $��4* �6$   �� 5,      $��* �6$   .+�5/      �� $��0��6   $��1q�6&   
�������$ 8��6M   $��50 40 50 30q�6^   ._�50      �  51      �� 52      $
��0.4* �6,   �� 53      $��* �6,   �� 54      $��* �6,   �� 55      $��* �6,   �� 56      $��* �6,   �� 57      $��0.55* �6,    � ColumnDefinitions 59      �� 5:      $��* �6/   �� 5;      $
��1.5* �6/   .+�5>      �� $��1��6$   $��0��61   $��20(�6A   $��Center=�6O   $��Center=�6j   $��20 0 0 0q�6�   事件名称6�   �� 5?      -   5        $��names��5?   �   $��1��6"   $��1��6/   $��20(�6?   $��Center=�6M   $��Center=�6h   $��0 0 40 0q�6�   6�   �� 5A      $��2��6$   $��0��61   $��20(�6A   $��Center=�6O   $��Center=�6j   $��20 0 0 0q�6�   事件描述6�   �� 5B      -   5        $��events��5B   �   $��2��6"   $��1��6/   $��20(�6?   $��Center=�6M   $��Center=�6h   $��0 0 40 0q�6�   6�   �� 5D      $��3��6$   $��0��61   $��20(�6A   $��Center=�6O   $��Center=�6j   $��20 0 0 0q�6�   开始时间6�   �� 5E      -   5        $��start��5E   �   $��3��6"   $��1��6/   $��20(�6?   $��Center=�6M   $��Center=�6h   $��0 0 40 0q�6�   6�   �� 5G      $��4��6$   $��0��61   $��20(�6A   $��Center=�6O   $��Center=�6j   $��20 0 0 0q�6�   结束时间6�   �� 5H      -   5        $	��end��5H   �   $��4��6"   $��1��6/   $��20(�6?   $��Center=�6M   $��Center=�6h   $��0 0 40 0q�6�   6�   5I      5J      � 5L      $��1��6    5M      �� 5N      $��* �6+   �� 5O      $
��Auto �6+   �� 5P      $
��Auto �6+   �� 5Q      $��* �6+   .+�5T      �� $��1��6   #��[ 6-   $��38��6V   $	��100��6b   $��20(�6n   
�������$	��Top=�6�   $��0 0 70 0q�6�   .��6�   确定6�   �� 5U      $��2��6   #��[ 6-   $��38��6V   $	��100��6b   $��20(�6n   
�������$	��Top=�6�   .��6�   取消6�   5V      5W      5X      5Y      5Z      