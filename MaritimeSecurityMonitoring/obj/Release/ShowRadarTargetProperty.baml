   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null8    2MaritimeSecurityMonitoring.ShowRadarTargetProperty   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  雷达��$	��740��$	��740��$	��740��$	��380��$	��380��$	��380�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius 
 Cancel��%�   &	        &	 o     �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q���  J� InputBindings �� 
 �� Key$	 Esc��	 �� Command#	 [ 
 J� CommandBindings
 )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve#��[  $��20(�
�������.��
  雷达�� -   $��22��$��22��$��0 0 20 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0 3 0 0q�
����������	#FF4A79D8$ 0 0 8 8��._��  �� $
��0.3* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.5* � � ColumnDefinitions �� $
��0.1* ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��0.1* �.+��� $��1��$��1��$��20(�
�������$��Center=�雷达1批号�� -   $��radarNumber��$��1��$��2��$��20(� �� 
IsReadOnly . 
������ 
�������$��2q�
�������$��Center=�$��Center=��� $��1��$��3��$��20(�
�������$��Center=�$��	35 0 10 0q�雷达2批号�� -   $��radarNumber2��$��1��$��4��$��20(� . 
������ 
�������$��2q�
�������$��Center=�$��Center=��� $��2��$��1��$��20(�
�������$��Center=�航向角（°）�� -   $��
trackAngle��$��2��$��2��$��20(� . 
������ 
�������$��2q�
�������$��Center=�$��Center=��� $��2��$��3��$��20(�
�������$��Center=�$��35 0 0 0q�距离（米）�� -   $��distance��$��2��$��4��$��20(� . 
������ 
�������$��2q�
�������$��Center=�$��Center=��� $��3��$��1��$��20(�
�������$��Center=�真北方位�� -   $��north��$��3��$��2��$��20(� . 
������ 
�������$��2q�
�������$��Center=�$��Center=��� $��3��$��3��$��20(�
�������$��Center=�$��35 0 0 0q�经度（°）�� -	   $��	longitude��$��3��$��4��$��20(� . 
������ 
�������$��2q�
�������$��Center=�$��Center=��� $��4��$��1��$��20(�
�������$��Center=�$��0 0 5 0q�对地速度（节）�� -
   $��speed��$��4��$��2��$��20(� . 
������ 
�������$��2q�
�������$��Center=�$��Center=��� $��4��$��3��$��20(�
�������$��Center=�$��35 0 0 0q�纬度（°）�� -   $��lagitude��$��4��$��4��$��20(� . 
������ 
�������$��2q�
�������$��Center=�$��Center=��� $��5��$��1��$��20(�
�������$��Center=�发现时间�� -   $��	findeTime��$��5��$��2��$��20(� . 
������ 
�������$��2q�
�������$��Center=�$��Center=�