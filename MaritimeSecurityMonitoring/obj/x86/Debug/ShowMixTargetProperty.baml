   M S B A M L   `   `   `  ����  MaritimeSecurityMonitoring6    0MaritimeSecurityMonitoring.ShowMixTargetProperty   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  融合��5   	   $	��670��6   $	��670��6    $	��670��6/   $	��530��6>   $	��530��6K   $	��530��6[    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�6O    � 	Resources 5         CornerLabel �� 
TargetType �� CornerRadius��%�   &	        �� 5   
   " ��6.   .R�5      �� $��0q�6   $ 8,8,0,0��6)   ���	#FF4A79D8._�5	      �� #��z��6#   $
��Left=�6V   $��Center=�6q   $��10 0 0 0q�6�   5
      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6Y   #��[  6   $��20(�68   
�������.��6n   
  融合6t   �� 5   
   -   5        $��22��5      $��22��6   $��0 0 19 0q�6(   $��Right=�6:   $��0q�6V   .��5      �� $��Image/Close_new.png��6   ��5      �� 5      	 �� Color$	 	#FF4A79D8��6"   5      �� 5   
   $��1��6   $��0 3 0 0q�6   
����������	#FF4A79D8$ 0 0 8 8��6c   ._�5      �  5      �� 5      $
��0.3* �6$   �� 5      $��* �6$   �� 5       $��* �6$   �� 5!      $��* �6$   �� 5"      $��* �6$   �� 5#      $��* �6$   �� 5$      $��* �6$   �� 5%      $��* �6$   �� 5&      $��* �6$   �� 5'      $
��0.5* �6$   
 � ColumnDefinitions
 5)      �� 5*      $
��0.1* �6'   �� 5+      $
��Auto �6'   �� 5,      $��* �6'   �� 5-      $
��Auto �6'   �� 5.      $��* �6'   �� 5/      $
��0.1* �6'   .+�52      �� $��1��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   融合批号6{   �� 53      -   5        $��	mixNmuber��53   �   $��1��6   $��2��6'   $��20(�67    �� 
IsReadOnly . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 54      $��1��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   船名6�   �� 55      -   5        $��boatName��55   �   $��1��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 57      $��2��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   发现时间6{   �� 58      -   5        $��findTime��58   �   $��2��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 59      $��2��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   呼号6�   �� 5:      -   5        $��
boatNumber��5:   �   $��2��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5<      $��3��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   融合类型6{   �� 5=      -   5        $��mixType��5=   �   $��3��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5>      $��3��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   国籍6�   �� 5?      -   5        $��country��5?   �   $��3��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5A      $��4��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   $��0 0 10 0q�6u   子源个数6�   �� 5B      -	   5        $��srcNum��5B   �   $��4��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5C      $��4��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��	35 0 10 0q�6u   最大吃水6�   �� 5D      -
   5        $
��high��5D   �   $��4��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5F      $��5��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   融合经度6{   �� 5G      -   5        $��	longitude��5G   �   $��5��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5H      $��5��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   船载人数6�   �� 5I      -   5        $��peopleNumber��5I   �   $��5��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5K      $��6��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   融合纬度6{   �� 5L      -   5        $��lagitude��5L   �   $��6��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5M      $��6��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   	目的地6�   �� 5N      -   5        $��distination��5N   �   $��6��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5P      $��7��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   距离6y   �� 5Q      -   5        $��distance��5Q   �   $��7��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5R      $��7��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   雷达批号6�   �� 5S      -   5        $��raderNumber��5S   �   $��7��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5U      $��8��6   $��1��6)   $��20(�69   
�������$��Center=�6Z   	方位角6z   �� 5V      -   5        $��angle��5V   �   $��8��6   $��2��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   �� 5W      $��8��6   $��3��6)   $��20(�69   
�������$��Center=�6Z   $��35 0 0 0q�6u   IMO6�   �� 5X      -   5        $	��IMO��5X   �   $��8��6   $��4��6'   $��20(�67    . 
������ 
�������$��2q�6�   
�������$��Center=�6�   $��Center=�6�   6�   5Y      5Z      5[      5\      