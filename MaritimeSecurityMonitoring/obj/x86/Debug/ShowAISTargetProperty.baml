   M S B A M L   `   `   `  ����  MaritimeSecurityMonitoring6    0MaritimeSecurityMonitoring.ShowAISTargetProperty   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$	  AIS��5   	   $	��650��6   $	��650��6!   $	��650��60   $	��480��6?   $	��480��6L   $	��480��6\    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�6O    � 	Resources 5         CornerLabel �� 
TargetType �� CornerRadius��%�   &	        �� 5   
   " ��6.   .R�5      �� $��0q�6   $ 8,8,0,0��6)   ���	#FF4A79D8._�5	      �� #��z��6#   $
��Left=�6V   $��Center=�6q   $��10 0 0 0q�6�   5
      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6Y   #��[  6   $��20(�68   
�������.��6n     AIS6u   �� 5   
   -   5        $��22��5      $��22��6   $��0 0 18 0q�6(   $��Right=�6:   $��0q�6V   .��5      �� $��Image/Close_new.png��6   ��5      �� 5      	 �� Color$	 	#FF4A79D8��6"   5      �� 5   
   $��1��6   $��0 3 0 0q�6   
����������	#FF4A79D8$ 0 0 8 8��6c   ._�5      �  5      �� 5      $
��0.3* �6$   �� 5      $��* �6$   �� 5       $��* �6$   �� 5!      $��* �6$   �� 5"      $��* �6$   �� 5#      $��* �6$   �� 5$      $��* �6$   �� 5%      $��* �6$   �� 5&      $
��0.5* �6$   
 � ColumnDefinitions
 5(      �� 5)      $
��0.1* �6'   �� 5*      $
��Auto �6'   �� 5+      $��* �6'   �� 5,      $
��Auto �6'   �� 5-      $��* �6'   �� 5.      $
��0.1* �6'   .+�51      �� $��1��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   船名6y   �� 52      -   5        $��boatName��52   �   $��1��6   $��2��6'   $��20(�67    �� 
IsReadOnly . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 53      $��1��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   	航向角6�   �� 54      -   5        $��
trackAngle��54   �   $��1��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 56      $��2��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   IMO6z   �� 57      -   5        $	��IMO��57   �   $��2��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 58      $��2��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   对地速度6�   �� 59      -   5        $��speed��59   �   $��2��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5;      $��3��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   $��0 0 8 0q�6u   MMSI6�   �� 5<      -   5        $
��MMSI��5<   �   $��3��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5=      $��3��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��	35 0 10 0q�6u   发现时间6�   �� 5>      -   5        $��findTime��5>   �   $��3��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5@      $��4��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   呼号6y   �� 5A      -	   5        $��
boatNumber��5A   �   $��4��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5B      $��4��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   航行状态6�   �� 5C      -
   5        $��trackStatus��5C   �   $��4��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5E      $��5��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   国籍6y   �� 5F      -   5        $��country��5F   �   $��5��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5G      $��5��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   最大吃水6�   �� 5H      -   5        $
��high��5H   �   $��5��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5J      $��6��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   经度6y   �� 5K      -   5        $��	longitude��5K   �   $��6��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5L      $��6��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   船载人数6�   �� 5M      -   5        $��peopleNumber��5M   �   $��6��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5O      $��7��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   纬度6y   �� 5P      -   5        $��latitude��5P   �   $��7��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5Q      $��7��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   	目的地6�   �� 5R      -   5        $��destination��5R   �   $��7��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   5S      5T      5U      5V      