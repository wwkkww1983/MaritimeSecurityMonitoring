   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  5    /MaritimeSecurityMonitoring.ScanParameterSetting   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6m(clr-namespace:MaritimeSecurityMonitoring     -     � Title$  扫描参数设置��$	��600��$	��600��$	��600��$	��360��$	��360��$	��360�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  UpTriButton �Name �� Stretch � Points �� Color  BottomTriButton  TextBoxErrorTemp �� 
TargetType �� Triggers �� ElementName �� Path 
 Cancel��%�  &	        &	 o     &	 f    &	 n    &	 r    &	 �    �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2�� " ��.R�� .+�� $ ButtonPolygon��$
 Fill=� �   ��� @KL ��� ��� ���� $ 	#FF4A79D8�� P� 	 �@J�IsMouseOver
 . . ��� $ ButtonPolygon�� � ��
 �����P� 	 � ��
 . . ��� $ ButtonPolygon�� � ��
 �   ��� " ��.R�� .+�� $ ButtonPolygon��$
 Fill=� �   ��� @KL ��� ���� $ 	#FF4A79D8�� P� 	 �@J�IsMouseOver
 . . ��� $ ButtonPolygon�� � ��
 �����P� 	 � ��
 . . ��� $ ButtonPolygon�� � ��
 �   ��� " �� P� 	 �@=�HasError
 . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� $��Bottom=�
���  ��$��14(�$
��Bold"�$��Center=����� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��2q�$��78��._��� $��	MyAdorner����  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��扫描参数设置�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������ $ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��3.8* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��45 40 45 30q�._�� $��	0 25 0 25q� �� $��* ��� $��* �.+�� $��0��$��Center=�$
��Left=�$��35 0 0 0q�.+��� $��20(�两个扫描边界角度�� $��1q�
�������$ 2��$��5 0 5 0q�._��  � ColumnDefinitions �� $��* ��� $
��Auto �.+��� -    ��Name$ Angle1��$��0��#��[ $��60��$��20(�$��0q�
������ $��Center=�$��Center=�.������ $ angle1� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  �� NotifyOnValidationError  . ! �� ValidationRules! ;   5MaritimeSecurityMonitoring.NumberValidationRuleForInt  -   	rule1��
"   Min$
" -179��
#   Max$	# 180��.��� $��1�� �� $��* ��� $��* �.+��� -   $��0��#��[ $��8��$	��2 1q�
$ � Tag$$ Angle1���� -   $��1��#��[ $��8��$	��2 1q�$$ Angle1���� $��20(�度，�� $��1q�
�������$ 2��$��0 0 5 0q�._��  �� $��* ��� $
��Auto �.+��� -   $ Angle2��$��0��#��[ $��60��$��20(�$��0q�
������ $��Center=�$��Center=�.������ $ angle2�$ TwoWay=�$ PropertyChanged=�  . !   -	   	rule2��$
" -179��$	# 180��.��� $��1�� �� $��* ��� $��* �.+��� -
   $��0��#��[ $��8��$	��2 1q�$$ Angle2���� -   $��1��#��[ $��8��$	��2 1q�$$ Angle2���� $��20(�度� $��1��$��Center=�$
��Left=�$��35 0 0 0q�.+��� $��20(�53扫描速度相当于摇杆操作时最大速度的�� $��1q�
�������$ 2��$��5 0 5 0q�._��  �� $��* ��� $
��Auto �.+��� -   $ Percent��$��0��#��[ $��60��$��20(�$��0q�
������ $��Center=�$��Center=�.������ $ percent�$ TwoWay=�$ PropertyChanged=�  . !   -   	rule3��$" 20��$	# 100��.��� $��1�� �� $��* ��� $��* �.+��� -   $��0��#��[ $��8��$	��2 1q�$$ Percent���� -   $��1��#��[ $��8��$	��2 1q�$$ Percent���� $��20(�%�� $��0��$��20(����	#FF4A79D8
�������$	��Top=�$
��Left=�$��	62,28,0,0q�方位扫描� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��35��$	��100��$��20(�
�������$	��Top=�$��0 0 80 0q�.��确定�� -   $��2��#��[ $��35��$	��100��$��20(�
�������$	��Top=�.��取消