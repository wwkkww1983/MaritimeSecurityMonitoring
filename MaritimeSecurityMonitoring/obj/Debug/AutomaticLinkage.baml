   M S B A M L   `   `   `  ����H  DNVRCsharpDemo, Version=2.0.1.1, Culture=neutral, PublicKeyToken=nullD2clr-namespace:NVRCsharpDemo;assembly=NVRCsharpDemoNVRCsharpDemo  5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5   	   U QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null1   +MaritimeSecurityMonitoring.AutomaticLinkage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   BDVR2clr-namespace:NVRCsharpDemo;assembly=NVRCsharpDemo     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   -   5          � Title$  防护圈参数设置��5   
   $	��550��6   $	��550��6&   $	��550��65   $	��380��6D   $	��380��6Q   $	��380��6a    � WindowStyle$
 None=�6q    � 
ResizeMode$ NoResize=�6�    � 	Resources 5         CornerButton �� 
TargetType ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName �� Property �� Value 
 Cancel��%�  &	        &	 �    �� 5   
   " ��6/   .R�5	      �� $ bd��6   $��0q�6!   $ 5 5 5 5��65   ���	#FF4A79D8._�5
      �� #��z��6#   $��Center=�6V   $��Center=�6s   5       5      P� 5       �@J�IsMouseOver	 . . �5      �� $
 bd��6    � �� �	#FF6D9DFF6C   5      P� 5       � ��	 . . �5      �� $
 bd��6    � �� �	#FF005AE26C   5      5      �� 5   
   6   5       J� InputBindings 5      �� 5   
   
 �� Key$	 Esc��6    �� Command# [ 6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6b   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5       $��* �6   �� 5!      $��50 �6   .+�5$   
   �� $��0��6   $��0��6   $��2��6.   ���	#FF4A79D8$��4q�6W   6m   �� 5%   
   ���	#FF4A79D8
�������$
��Left=�6:   $��Center=�6\   $��17(�6~   .��6�   联动控制6�   �� 5&   
   -   5        $��Right=�5&      $��22��6.   $��22��6:   $��0q�6E   $��2q�6Y   ��5'      �� 5(       �� ImageSource$ Image\Close_new.png��6    j� Stretch$
 Fill=�6?   6P   5*      7  1System.Windows.Forms.Integration.WindowsFormsHost  5+   
   $��1��6      Child. 5-         NVRCsharpDemo.mypanel  -   5        connectPictureBox��[ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  System.Windows.Forms.Control   Margin+  %System.Windows.Forms.PaddingConverter$ 0,0,0,0 5-   5   6H   5.      �� 5/   
   -   5        $��2��5/      #��[  6   $��Center=�6H   $��30��6e   $��55��6q   
�������$��2q�6�   .��6�   截图6�   50      51      