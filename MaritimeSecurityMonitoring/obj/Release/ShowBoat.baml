   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null)    #MaritimeSecurityMonitoring.ShowBoat   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  船舶显示��$	��540��$	��540��$	��540��$	��360��$	��360��$	��360�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value��%z  &	        &	 o     �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2.���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��船舶显示�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��3.5* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��50 40 50 30q�._��  �� $
��0.5* ��� $��* ��� $��* ��� $
��0.6* � � ColumnDefinitions �� $��0.35* ��� $
��Auto ��� $
��Auto ��� $
��0.5* ��� $
��Auto ��� $
��Auto ��� $
��0.4* �.+��� $��1��$��1��$��20(�$��Center=��� $��1��$��2��$��20(�$��Center=�$��10 0 0 0q�船舶标识�� $��1��$��4��$��20(�$��Center=��� $��1��$��5��$��20(�$��Center=�$��10 0 0 0q�	呼叫号�� $��2��$��1��$��20(�$��Center=��� $��2��$��2��$��20(�$��Center=�$��10 0 0 0q�	航首线�� $��2��$��4��$��20(�$��Center=��� $��2��$��5��$��20(�$��Center=�$��10 0 0 0q�	航迹线� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��#��[ $��38��$	��100��$��20(�
�������$	��Top=�$��0 0 80 0q�.��确定�� $��2��#��[ $��38��$	��100��$��20(�
�������$	��Top=�.��取消