   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null8    2MaritimeSecurityMonitoring.TrackAlgorithmSelection   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  跟踪算法选择��$	��350��$	��350��$	��350��$	��300��$	��300��$	��300�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value��%z  &	        &	 o     �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2.���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��跟踪算法选择�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $��3* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��40 30q�._��  �� $��* ��� $��* �.+�	� $��0��$��20(�$��Center=�$��Center=�$��Center=� d� 	IsChecked$
 TrueY�$��0 10 0 0q�.��相关跟踪	� $��1��$��20(�$��Center=�$��Center=�$��Center=�$��0 0 0 10q�.��核心跟踪� $��1�� � ColumnDefinitions �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��#��[ $��35��$��90��$��20(�
�������$	��Top=�$��0 0 50 0q�.��确定�� $��2��#��[ $��35��$��90��$��20(�
�������$	��Top=�.��取消