   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  2    ,MaritimeSecurityMonitoring.TargetWakeSetting   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  4local(clr-namespace:MaritimeSecurityMonitoring  -     � Title$  目标尾迹��$	��580��$	��580��$	��580��$	��360��$	��360��$	��360�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  TextBoxErrorTemp �� 
TargetType �� Triggers �� ElementName �� Path��%�  &	        &	 o     &	 f    �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2�� " �� P� 	 �@=�HasError
 . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� $��Bottom=�
���  ��$��14(�$
��Bold"�$��Center=����� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��2q�$��80��._��� $��	MyAdorner��.���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��目标尾迹�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��3.8* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��45 40 45 20q�._��  �� $��0.45* ��� $��* ��� $��* ��� $
��0.5* � � ColumnDefinitions �� $��0.45* ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��0.5* �.+�	� $��1��$��1��$��20(�$��Center=�$��Center=� d� 	IsChecked$
 TrueY�.��折线�� $��1��$��2��$��20(�$��Center=�$��40 0 5 0q�线宽�� $��1��$��3��#��[ $��20(�$��Center=�$��Center=�.������ $ width� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� ValidationRules =   7MaritimeSecurityMonitoring.NumberValidationRuleForFloat  
   Max$ 10��
   Min$ 0.00001��.���� $��1��$��4��$��20(�$��Center=�$��30 0 8 0q�当前颜色#  Xceed.Wpf.Toolkit.ColorPicker  $��1��$��5��   SelectedColor$	 RedX�   ShowDropDownButton .  $��0q�$��Center=�	� $��2��$��1��$��20(�$��Center=�$��Center=�.��点线�� $��2��$��2��$��20(�$��Center=�$��40 0 5 0q�半径�� $��2��$��3��#��[ $��20(�$��Center=�$��Center=�.������ $ radius�$ TwoWay=�$ PropertyChanged=� .    $ 10��$ 0.00001��.���� $��2��$��4��$��20(�$��Center=�$��30 0 8 0q�当前颜色  $��2��$��5��$ GreenX� .  $��0q�$��Center=�� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��#��[ $��35��$	��100��$��20(�
�������$	��Top=�$��0 0 80 0q�.��确定�� $��2��#��[ $��35��$	��100��$��20(�
�������$	��Top=�.��取消