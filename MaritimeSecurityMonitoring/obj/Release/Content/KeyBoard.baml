   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullW0clr-namespace:MaritimeSecurityMonitoring.Content"MaritimeSecurityMonitoring.Content  1    +MaritimeSecurityMonitoring.Content.KeyBoard   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Blocal0clr-namespace:MaritimeSecurityMonitoring.Content     -     � 	Resources     	KeyButton �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration	 �� 
TargetName
 �� TargetProperty	 �� To ��Name ��Name �� 
StartPoint �� EndPoint � Color � Offset ��Name  ToggleKeyButton��%�  &	        &	 l    �� " ��.���  � ��
 �������  � ��$	 1,2q���  � ��$ 24����  � ��$ 24����  � ��$ .5q���  � �� �� " ��.R��    CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�$ #47C9FBX��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�$ #2BA8E8X��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�$ #1097D7X�  Pressed��. �� .���� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�$ #1097D7X��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�$ #2BA8E8X��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�$ #47C9FBX�  Disabled��  FocusStates��.   Focused��  	Unfocused��.+��� $ 
Background��
�������#��z��#��z��._�� #��z��.+��� $ BackgroundGradient������ $
 .5,0&�$
 .5,1&�.��� $ White��$ 0Q�� $ White��$	 0.4Q�� $ White��$ 1Q��� $ contentPresenter��#��z��#��z��#��z��#��z��#��z���� " d�.���  � ��
 �������  � ��$	 1,2q���  � ��$ 24����  � ��$ 24����  � ��$ .5q���  � �� �� " d�.R��    CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�$ #47C9FBX��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�$ #2BA8E8X��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�$ #1097D7X�  Pressed��. �� .���� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�$ #1097D7X��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�$ #2BA8E8X��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�$ #47C9FBX�  Checked��. �� .���� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�$ #1097D7X��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�$ #2BA8E8X��� $ 0D�$	 BackgroundGradient��$L
 F(Rectangle.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Color)�$ #47C9FBX�  Disabled��  FocusStates��.   Focused��  	Unfocused��.+��� $ 
Background��
�������#��z��#��z��._�� #��z��.+��� $ BackgroundGradient������ $
 .5,0&�$
 .5,1&�.��� $ White��$ 0Q�� $ White��$	 0.4Q�� $ White��$ 1Q��� $ contentPresenter��#��z��#��z��#��z��#��z��#��z��.���� ���#2092D8���#043150$��1q� �� CornerRadius$ 2��._��  � RowDefinitions �� �� �� �� .+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ btnNum2��$��10,2,1,2q�#��[  .��2�� -   $ btnNum3��#��[  .��3�� -   $ btnNum4��#��[  .��4�� -   $ btnNum5��#��[  .��5�� -   $ btnNum6��#��[  .��6�� -   $ btnNum7��#��[  .��7�� -   $ btnNum8��#��[  .��8�� -	   $ btnNum9��#��[  .��9�� -
   $ btnNum0��#��[  .��0�� -   $ btnDot��#��[  .��`�� -   $ btnNum1��#��[  .��1�� -   $ 	btnDelete��#��[  $��45��.��←�� $ 
Horizontal=�$��1��.+�d� -    d�Name$ btnShift��$��2,2,1,2q�#��[ $��30��.��Shift�� -   $ btnBackslant��#��[  .��\�� -   $ btnLParenthesis��#��[  .��[�� -   $ btnRParenthesis��#��[  .��]�� -   $ btnSemicolon��#��[  .��;�� -   $ 
btnSQuotes��#��[  .��'�� -   $ btnComma��#��[  .��,�� -   $ 	btnPeriod��#��[  .��.�� -   $ btnSlant��#��[  .��/�� -   $ btnSub��#��[  .��-�� -   $ btnEquip��#��[  .��=d� -   $ btnCapsLock��#��[ $��62��.��	Caps Lock�� $ 
Horizontal=�$��2��.+��� -   $
 btnj��$��10,2,1,2q�#��[  .��j�� -   $
 btnk��#��[  .��k�� -   $
 btnl��#��[  .��l�� -   $
 btnm��#��[  .��m�� -   $
 btna��#��[  .��a�� -   $
 btnb��#��[  .��b�� -    $
 btnc��#��[  .��c�� -!   $
 btnd��#��[  .��d�� -"   $
 btne��#��[  .��e�� -#   $
 btnf��#��[  .��f�� -$   $
 btng��#��[  .��g�� -%   $
 btnh��#��[  .��h�� -&   $
 btni��#��[  .��i�� $ 
Horizontal=�$��3��.+��� -'   $
 btnp��$��10,2,1,2q�#��[  .��p�� -(   $
 btnq��#��[  .��q�� -)   $
 btnr��#��[  .��r�� -*   $
 btns��#��[  .��s�� -+   $
 btnt��#��[  .��t�� -,   $
 btnu��#��[  .��u�� --   $
 btnv��#��[  .��v�� -.   $
 btnw��#��[  .��w�� -/   $
 btnx��#��[  .��x�� -0   $
 btny��#��[  .��y�� -1   $
 btnz��#��[  .��z�� -2   $
 btnn��#��[  .��n�� -3   $
 btno��#��[  .��o