   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  5    /MaritimeSecurityMonitoring.DefenseCircleSetting   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6m(clr-namespace:MaritimeSecurityMonitoring     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  圈层参数设置��$	��580��$	��580��$	��580��$	��360��$	��360��$	��360�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  TextBoxErrorTemp �� 
TargetType �� Triggers �� ElementName �� Path 
 Cancel��%�  &	        &	 o     &	 f    &	 �    �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2�� " �� P� 	 �@=�HasError
 . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� $��Bottom=�
���  ��$��14(�$
��Bold"�$��Center=����� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��2q�$��67��._��� $��	MyAdorner����  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��圈层参数设置�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��3.8* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��45 40 45 20q�._��  �� $
��0.6* ��� $��* ��� $��* ��� $��* ��� $
��0.6* � � ColumnDefinitions �� $
��0.7* ��� $��0.23* ��� $
��0.4* ��� $��0.47* ��� $��0.45* ��� $��0.55* �.+��� $��1��$��0��$��20(�$��Center=�$��Center=�	驱逐区�� $��1��$��1��$��20(�$��Center=�$��Center=�半径�� -   $��alarm1��$��1��$��2��#��[ $��20(�$��Center=�$��Center=�$��Center=�$	��3 0q�.������ $ r1� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� ValidationRules =   7MaritimeSecurityMonitoring.NumberValidationRuleForFloat  -   	rule1��
   Min$ 0.00001��
   Max$ 20��.���� $��1��$��3��$��20(�$��Center=�$��Center=�
公里(km)�� $��1��$��4��$��20(�$��Right=�$��Center=�颜色#  Xceed.Wpf.Toolkit.ColorPicker  -   $��color1��$��1��$��5��    SelectedColor$	  RedX�!   ShowDropDownButton! .  $��0q�$��Center=�$��5 0 40 0q��� $��2��$��0��$��20(�$��Center=�$��Center=�	警戒区�� $��2��$��1��$��20(�$��Center=�$��Center=�半径�� -   $��alarm2��$��2��$��2��#��[ $��20(�$��Center=�$��Center=�$��Center=�$	��3 0q�.������ $ r2�$ TwoWay=�$ PropertyChanged=� .    -   	rule2��$ 0.00001��$ 20��.���� $��2��$��3��$��20(�$��Center=�$��Center=�
公里(km)�� $��2��$��4��$��20(�$��Right=�$��Center=�颜色  -	   $��color2��$��2��$��5��$  GreenX�! .  $��0q�$��Center=�$��5 0 40 0q��� $��3��$��0��$��20(�$��Center=�$��Center=�	预警区�� $��3��$��1��$��20(�$��Center=�$��Center=�半径�� -
   $��alarm3��$��3��$��2��#��[ $��20(�$��Center=�$��Center=�$��Center=�$	��3 0q�.������ $ r3�$ TwoWay=�$ PropertyChanged=� .    -   	rule3��$ 0.00001��$ 20��.���� $��3��$��3��$��20(�$��Center=�$��Center=�
公里(km)�� $��3��$��4��$��20(�$��Right=�$��Center=�颜色  -   $��color3��$��3��$��5��$  YellowX�! .  $��0q�$��Center=�$��5 0 40 0q�� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��35��$	��100��$��20(�
�������$	��Top=�$��0 0 80 0q�.��确定�� -   $��2��#��[ $��35��$	��100��$��20(�
�������$	��Top=�.��取消