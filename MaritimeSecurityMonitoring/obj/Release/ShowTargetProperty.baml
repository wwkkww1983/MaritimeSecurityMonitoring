   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null3    -MaritimeSecurityMonitoring.ShowTargetProperty   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  目标属性显示��$	��480��$	��480��$	��480��$	��350��$	��350��$	��350�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value 
 Cancel��%�  &	        &	 o     &	 f    �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2��  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��目标属性显示�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��3.2* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��50 40 50 35q�._��  �� $
��0.3* ��� $��* ��� $��* ��� $��0.35* � � ColumnDefinitions �� $��* ��� $��* �.+�� $��1��$��0��$��Center=�$
��Left=�$��50 0 0 0q�.+��� -   $��shipName��$��20(�$��Center=�$��0 0 10 0q��� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve$��20(�船名� $��1��$��1��$��Center=�$
��Left=�.+��� -   $��	shipSpeed��$��20(�$��Center=�$��0 0 10 0q���  preserve$��20(�船速� $��2��$��0��$��Center=�$
��Left=�$��50 0 0 0q�.+��� -   $��angle��$��20(�$��Center=�$��0 0 10 0q���  preserve$��20(�	航向角� $��2��$��1��$��Center=�$
��Left=�.+��� -   $��
arriveTime��$��20(�$��Center=�$��0 0 10 0q���  preserve$��20(�到达平台时间� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��38��$	��100��$��20(�
�������$	��Top=�$��0 0 80 0q�.��确定�� -	   $��2��#��[ $��38��$	��100��$��20(�
�������$	��Top=�.��取消