   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null+    %MaritimeSecurityMonitoring.ConfirmBox   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$
  main�� � Title$ 
ConfirmBox��$	��130��$	��280�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=���Z�  � 	Resources    CornerButton �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value 
 Cancel��%
  &	        &	 �     �� " ��.R��� $ bd��$��0q�$	 3�����	#FF4A79D8._��� #��z��$��Center=�$��Center=�
 P�  �@J�IsMouseOver . . ��� $ bd�� � �� �	#FF6D9DFFP�  � �� . . ��� $ bd�� � �� �	#FF005AE2��  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���� $��0q�
������� J� Opacity$ 1Q�$	 5��._��� .+��� 
 �� Top$ 0��$��25��$��0q����	#FF4A79D8$	 5 5 0 0������  �� ElementName$
 main�� �� Path$ Width� �� UpdateSourceTrigger$ PropertyChanged=�._��� -    ��Name$ lblTitle��$��title��$
��Left=�
�������$��14(�$��Center=�$��5 3 5 3q��� $ 25��$	��105��$��1q����	#FF4A79D8$	 0 0 5 5������ $
 main��$ Width�$ PropertyChanged=��� -   $ lblMsg��$��16(�$
��Wrap=�$��message��$��Center=� �� Left$ 20��$ 50���� -   #��[  $��22��$��50��
������� �� Bottom$ 10��$ 70��.��确定�� -   #��[  $��22��$��50��
�������$ 10�� �� Right$ 70��.��取消