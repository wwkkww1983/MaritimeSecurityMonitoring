   M S B A M L   `   `   `  ����  MaritimeSecurityMonitoring/    )MaritimeSecurityMonitoring.WinProgressBar   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  WinProgressBar��5   	   $	��150��6    $	��150��6-   $	��150��6=   $	��400��6M   $	��400��6Y   $	��400��6h    � Icon$ SmallLogo.png��6w    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�6O    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5         CornerLabel �� 
TargetType �� CornerRadius  CornerButton	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value �� 
TargetType��%�  &	        &	 �     '� Y    �� 5   
   " ��6.   .R�5      �� $��0q�6   $ 8,8,0,0��6)   ���	#FF4A79D8._�5	      �� #��z��6#   $
��Left=�6V   $��Center=�6q   $��10 0 0 0q�6�   5
      5      �� 5   
   " ��6/   .R�5      �� $	 bd��6   $��0q�6!   $ 5 5 5 5��65   ���	#FF4A79D8._�5      �� #��z��6#   $��Center=�6V   $��Center=�6s   5      
 5      P� 5       �@J�IsMouseOver . . �5      �� $ bd��6    � �� �	#FF6D9DFF6C   5      P� 5       � �� . . �5      �� $ bd��6    � �� �	#FF005AE26C   5      5      �� 5   
   " �6   .�5      ��  � �� 5      �� 5      " �6&   .R�5      � .+�5      �� $	 
PART_Track��6%   $��0q�69   ���	#FFEAEAEA6M   �� 5       $	 PART_Indicator��6%   $��0q�6=   $
��Left=�6Q   ���	#FF64B7FF6l   5!      5"      5$      5%      5&      .��5(      �  � RowDefinitions 5)   
   �� 5*      $��30 �6   �� 5+      $��* �6   .+�5.   
   �� #��[  6   $��18(�68   
�������.��6Y   正在加载系统6a   �� 50   
   $��1��6   $��0q�6   
�������$ 0 0 8 8��6E   ._�51      �  52      �� 53      $��* �6$   �� 54      $
��Auto �6$   .+�57      � -   5         �Name$ progressBar��57   n   $��Center=�6   $��Center=�6;   $	��300��6V   $��18��6b   $��0 5 0 0q�6�   �� 58      -   5        $��1��58      #��[ 6&   $��16(�6O   
�������$��60��6p   $��25��6{   $��0 0 0 15q�6�   .��6�   取消6�   59      5:      5;      5<      