   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null1    +MaritimeSecurityMonitoring.ShipNumberImport   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  船舷号导入��$	��250��$	��250��$	��250��$	��500��$	��500��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency . 
������  � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value 
 Cancel��%�  &	        &	 o     &	 f    �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2��  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��船舷号导入�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $��2* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��40 40 40 30q�._��  � ColumnDefinitions �� $
��0.1* ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��0.1* �.+��� $��1��$��20(�$��Center=�$��0 0 15 0q�文件�� -   $
��path��$��2��$��20(�$��Center=� �� 
IsReadOnly . �� -   $��3��$��30��$��0q�
������ $��Center=�$��10 0 0 0q�.���� $��image/folder.png��� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��38��$	��100��$��20(�
�������$	��Top=�$��0 0 70 0q�.��确定�� -   $��2��#��[ $��38��$	��100��$��20(�
�������$	��Top=�.��取消