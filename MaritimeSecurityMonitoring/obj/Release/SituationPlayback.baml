   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null2    ,MaritimeSecurityMonitoring.SituationPlayback   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  态势回放��$	��500��$	��500��$	��500��$	��400��$	��400��$	��400�� � WindowStyle$
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
�������.��态势回放�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��3.2* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��50 40q�._��  �� $��0.45* ��� $��* ��� $��* ��� $
��0.5* � � ColumnDefinitions �� $��* ��� $
��1.6* �.+��� $��1��$��0��$��20(�$��Center=�$��Center=�$��15 0 0 0q�开始时间&   Xceed.Wpf.Toolkit.DateTimePicker  -   $��startTimeText��$��1��$��1���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ShowButtonSpinner .  ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .     MouseWheelActiveOnFocus . $��16(�$��Center=�&   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�   FormatString$ yyyy/MM/dd HH:mm:ss��   
TimeFormat$ LongTime=�$��0 0 50 0q��� $��2��$��0��$��20(�$��Center=�$��Center=�$��15 0 0 0q�结束时间  -   $��endTimeText��$��2��$��1�� .   .   . $��16(�$��Center=�$ Custom=�$ yyyy/MM/dd HH:mm:ss��$ LongTime=�$��0 0 50 0q�� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��40��$	��100��$��20(�
�������$	��Top=�$��0 0 80 0q�.��确定�� -   $��2��#��[ $��40��$	��100��$��20(�
�������$	��Top=�.��取消