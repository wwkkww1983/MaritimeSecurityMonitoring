   M S B A M L   `   `   `  ����U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null+    %MaritimeSecurityMonitoring.ConfirmBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$
  main��5   t    � Title$ 
ConfirmBox��6	   $	��130��6   $	��280��6)    � WindowStyle$
 None=�65    � 
ResizeMode$ NoResize=�6^    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6�   ��6H   Z�  � 	Resources 5         CornerButton �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value 
 Cancel��%�  &	        &	 �    �� 5   
   " ��6/   .R�5      �� $ bd��6   $��0q�6!   $	 3��65   ���	#FF4A79D8._�5      �� #��z��6#   $��Center=�6V   $��Center=�6s   5	      
 5
      P� 5       �@J�IsMouseOver . . �5      �� $ bd��6    � �� �	#FF6D9DFF6C   5      P� 5       � �� . . �5      �� $ bd��6    � �� �	#FF005AE26C   5      5      �� 5   
   6   5       J� InputBindings 5      �� 5   
   
 �� Key$	 Esc��6    �� Command# [ 6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6b   .��5      �� $��0q�6   
������� J� Opacity$ 1Q�64   $	 5��6@   ._�5   
   �� .+�5      �� 
 �� Top$ 0��6   $��25��6$   $��0q�6�   ���	#FF4A79D8$	 5 5 0 0��6�   ��60   ��  �� ElementName$
 main�� �� Path$ Width� �� UpdateSourceTrigger$ PropertyChanged=�._�5      �� -   5         ��Name$ lblTitle��5      $��title��6.   $
��Left=�6;   
�������$��14(�6i   $��Center=�6w   $��5 3 5 3q�6�   5      �� 5       $ 25��6   $	��105��6%   $��1q�6�   ���	#FF4A79D8$	 0 0 5 5��6�   ��62   �� $
 main��$ Width�$ PropertyChanged=�6�   �� 5!      -   5        $ lblMsg��5!      $��16(�6(   $
��Wrap=�66   $��message��6J   $��Center=�6Y    �� Left$ 20��6v   $ 50��6�   �� 5"      -   5        #��[  5"      $��22��6>   $��50��6J   
������� �� Bottom$ 10��6h   $ 70��6{   .��6�   确定6�   �� 5#      -   5        #��[  5#      $��22��6>   $��50��6J   
�������$ 10��6h    �� Right$ 70��6{   .��6�   取消6�   5$      5%      5&      