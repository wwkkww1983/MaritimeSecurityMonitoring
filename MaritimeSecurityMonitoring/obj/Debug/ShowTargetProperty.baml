   M S B A M L   `   `   `  ����U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null3    -MaritimeSecurityMonitoring.ShowTargetProperty   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  目标属性显示��5   	   $	��480��6   $	��480��6$   $	��480��63   $	��350��6B   $	��350��6O   $	��350��6_    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�6O    � 	Resources 5         CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value 
 Cancel��%�  &	        &	 �     &	 Y    �� 5   
   " ��6.   .R�5      �� $��0q�6   $ 8,8,0,0��6)   ���	#FF4A79D8._�5	      �� #��z��6#   $
��Left=�6V   $��Center=�6q   $��10 0 0 0q�6�   5
      5      �� 5   
   " ��6/   .R�5      �� $ bd��6   $��0q�6!   $ 5 5 5 5��65   ���	#FF4A79D8._�5      �� #��z��6#   $��Center=�6V   $��Center=�6s   5       5      P� 5      	 �@J�IsMouseOver
 . . �5      �� $ bd��6    � �� �	#FF6D9DFF6C   5      P� 5      	 � ��
 . . �5      �� $ bd��6    � �� �	#FF005AE26C   5      5      �� 5   
   6   5       J� InputBindings 5      �� 5   
   
 �� Key$	 Esc��6    �� Command# [ 6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6b   .��5!      �  � RowDefinitions 5"   
   �� 5#      $��40 �6   �� 5$      $��* �6   .+�5'   
   �� #��[  6   $��20(�68   
�������.��6Y   目标属性显示6a   �� 5(   
   -   5        $��22��5(      $��22��6   $��0 0 10 0q�6(   $��Right=�6:   $��0q�6V   .��5)      �� $��Image/Close_new.png��6   ��5*      �� 5+       �� Color$ 	#FF4A79D8��6"   5-      �� 5/   
   $��1��6   $��0q�6   
�������$ 0 0 8 8��6E   ._�50      �  51      �� 52      $
��3.2* �6$   �� 53      $��* �6$   .+�56      �� $��0��6   $��1q�6&   
�������$ 8��6M   $��50 40 50 35q�6^   ._�57      �  58      �� 59      $
��0.3* �6,   �� 5:      $��* �6,   �� 5;      $��* �6,   �� 5<      $��0.35* �6,    � ColumnDefinitions 5>      �� 5?      $��* �6/   �� 5@      $��* �6/   .+�5C      � $��1��6$   $��0��61   $��Center=�6A   $
��Left=�6\   $��50 0 0 0q�6w   .+�5D      �� -   5        $��shipName��5D   b   $��20(�6'   $��Center=�65   $��0 0 10 0q�6P   6b   �� 5E      2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve66   $��20(�6(   船名6O   5F      � 5H      $��1��6$   $��1��61   $��Center=�6A   $
��Left=�6\   .+�5I      �� -   5        $��	shipSpeed��5I   b   $��20(�6'   $��Center=�65   $��0 0 10 0q�6P   6b   �� 5J       preserve66   $��20(�6(   船速6O   5K      � 5M      $��2��6$   $��0��61   $��Center=�6A   $
��Left=�6\   $��50 0 0 0q�6w   .+�5N      �� -   5        $��angle��5N   b   $��20(�6'   $��Center=�65   $��0 0 10 0q�6P   6b   �� 5O       preserve66   $��20(�6(   	航向角6P   5P      � 5R      $��2��6$   $��1��61   $��Center=�6A   $
��Left=�6\   .+�5S      �� -   5        $��
arriveTime��5S   b   $��20(�6'   $��Center=�65   $��0 0 10 0q�6P   6b   �� 5T       preserve66   $��20(�6(   到达平台时间6S   5U      5V      5W      � 5Y      $��1��6    5Z      �� 5[      $��* �6+   �� 5\      $
��Auto �6+   �� 5]      $
��Auto �6+   �� 5^      $��* �6+   .+�5a      �� -   5        $��1��5a      #��[ 6-   $��38��6V   $	��100��6b   $��20(�6n   
�������$	��Top=�6�   $��0 0 80 0q�6�   .��6�   确定6�   �� 5b      -	   5        $��2��5b      #��[ 6-   $��38��6V   $	��100��6b   $��20(�6n   
�������$	��Top=�6�   .��6�   取消6�   5c      5d      5e      5f      5g      