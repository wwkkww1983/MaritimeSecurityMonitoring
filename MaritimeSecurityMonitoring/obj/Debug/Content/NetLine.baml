   M S B A M L   `   `   `  ����U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullW0clr-namespace:MaritimeSecurityMonitoring.Content"MaritimeSecurityMonitoring.Content  5      ]3clr-namespace:MaritimeSecurityMonitoring.Converters%MaritimeSecurityMonitoring.Converters  5      0    *MaritimeSecurityMonitoring.Content.NetLine   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:MaritimeSecurityMonitoring.Content     5      Ac3clr-namespace:MaritimeSecurityMonitoring.Converters     5      -   5          >�Name$  netLine��5
       � 	Resources 5      E  ?MaritimeSecurityMonitoring.Converters.BoolToVisibilityConverter   boolToVisibilityConverter % !reversalBoolToVisibilityConverter   TrueVisibility   FalseVisibility��%Z   &	        &	        5   
   6&     5   
   $ Hidden=�6P   $ Visible=�6h   5      .��5      � $��11��6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��10 �6   �� 5      $��1* �6   .+�5   
   A� $
��Left=�6   
���  ��$��3��68   $��3��6C   y�6M   ��  �� ElementName$ netLine�� �� Path$ IsBroken� �� 	Converter# [  6�   �� 5   
   
���  ��$��1��6   $��
2, 0, 0, 0q�6*   $��Stretch=�6>   y�6\   �� $ netLine��$ IsBroken�# [  6�   �� 5   
   $��1��6   $��11��6!   $��10��6-   y�68   �� $ netLine��$ IsBroken�# [  .+�5      �� 
���  ��$��1��6#   $��12��6.   $��Center=�69    �� Left$ 1��6V   
	 �� Top$	 2��6f   z�5      �� 5      
 �� Angle$
 30Q�6&    �� CenterX$ 0Q�61    �� CenterY$ 0Q�6=   5      �� 5      
���  ��$��1��6#   $��12��6.   $��Center=�69   $ 0��6V   $	 8��6f   z�5      �� 5       $	
 -30Q�6&   $ 0Q�62   $ 0Q�6>   5"      5#      A� 5%   
   $��2��6�   $��Right=�6�   
���  ��$��3��6�   $��3��6�   y�6   �� $ netLine��$ IsBroken�# [  6�   �� 5&   
   $��2��6�   
���  ��$��1��6�   $��
0, 0, 2, 0q�6�   $��Stretch=�6�   y�6   �� $ netLine��$ IsBroken�# [  6�   A� 5(   
   $
��Left=�6   
��� � �$��3��6:   $��3��6E   y�6O   �� $ netLine��$ IsBroken�# [ 6�   �� 5)   
   $��3��6   $��
2, 0, 2, 0q�6(   $��1��6<   $��Stretch=�6G   
��� � �$��Center=�6s   y�6�   �� $ netLine��$ IsBroken�# [ A� 5*   
   $��2��6�   $��Right=�6�   
��� � �$��3��6�   $��3��6�   y�6   �� $ netLine��$ IsBroken�# [ 6�   5+      5,      