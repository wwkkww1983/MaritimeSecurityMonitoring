   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null+    %MaritimeSecurityMonitoring.TrackEvent   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  跟踪事件��$	��450��$	��520��$	��450��$	��520��$	��450��$	��520�� � WindowStyle$
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
�������.��跟踪事件�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $��4* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��50 40 50 30q�._��  �� $
��0.4* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��0.55* � � ColumnDefinitions �� $��* ��� $
��1.5* �.+��� $��1��$��0��$��20(�$��Center=�$��Center=�$��20 0 0 0q�事件名称�� -   $��names��$��1��$��1��$��20(�$��Center=�$��Center=�$��0 0 40 0q� �� 	MaxLength$ 40���� $��2��$��0��$��20(�$��Center=�$��Center=�$��20 0 0 0q�事件描述�� -   $��events��$��2��$��1��$��20(�$��Center=�$��Center=�$��0 0 40 0q�$	 100���� $��3��$��0��$��20(�$��Center=�$��Center=�$��20 0 0 0q�开始时间�� -   $��start��$��3��$��1��$��20(�$��Center=�$��Center=�$��0 0 40 0q� �� 
IsReadOnly . �� $��4��$��0��$��20(�$��Center=�$��Center=�$��20 0 0 0q�结束时间�� -   $	��end��$��4��$��1��$��20(�$��Center=�$��Center=�$��0 0 40 0q� . � $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��38��$	��100��$��20(�
�������$	��Top=�$��0 0 70 0q�.��确定�� -	   $��2��#��[ $��38��$	��100��$��20(�
�������$	��Top=�.��取消