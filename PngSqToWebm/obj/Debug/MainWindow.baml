   M S B A M L   `   `   `  ����F  BPngSqToWebm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PngSqToWebmPngSqToWebm  5   	       PngSqToWebm.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PngSqToWebm     5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;controls,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$%  PNG 시퀀스 -> Webm 변환기��5	   	   $��360         ��6%   $	��800��5
       � 
ResizeMode$ NoResize=�6    � 	Resources 5       �� 
TargetType �� Property �� Value   RadioButtonFocusVisual �� 
TargetType ��Name ��Name'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value R� KeyTime"  System.Windows.Media.Brushes   White R� Value��%N  '	�       �� 5   
   " 	�6   
BlockRadio��.�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       �@�FocusVisualStyle# �   61   �� 5       � �� 5      �� 5      " 	�6&   .R�5      �� ._�5      � .+�5   "   �� $
 Back��6,   
�������6:   �� 5   "   $ Border��6,   
���   �$��0��6K   �� 5   "   $ Label��6D   
���   �.��5   &   �� $	��5,0q�67   $��Center=�6D   $��Center=�6_   ��. 6|   5   #   5      	 5        5   "   CommonStates��.
 5   &     
Normal��62     5   &   	MouseOver��. 5   *   �� .��5    .   U� $ (Shape.StrokeThickness)�6L   $ Border��5!   2   .\�5"   2     $ 0��6G   $ 2Q�6S   5#   /   5$   +   5%   '     5&   &   Pressed��. 5'   *   �� .��5(   .   �� $* $(Shape.Fill).(SolidColorBrush.Color)�6K   $
 Back��5)   2   .g�5*   2     $ 0��6F   $ Black��6R   5+   /   T� 5,   .   $ (Control.Foreground)�6L   $ Label��5-   2   ..�5.   2   i� $ 0��6I   # Z 6U   5/   /   50   +   51   '   52   #     53   "   CheckStates��.
 54   &     Checked��. 55   *   �� .��56   .   �� $* $(Shape.Fill).(SolidColorBrush.Color)�6K   $
 Back��57   2   .g�58   2     $ 0��6F   $ Black��6R   59   /   T� 5:   .   $ (Control.Foreground)�6L   $ Label��5;   2   ..�5<   2   i� $ 0��6I   # Z 6U   5=   /   5>   +   5?   '     5@   &   	Unchecked��62     5A   &   Indeterminate��62   5B   #   5D      5E      5G      5H      5I      .��5J      � -   5         �Name$ 	Container��5J      .+�5K   
   �� -   5         ��Name$ SqLabel��5K      $��시퀀스 파일��6!   $
��Left=�62   $��	10,31,0,0q�6M   $	��Top=�6`   �� 5L   
   -   5         ��Name$ OpenPath��5L      $��23��6$   $��10,62,130,0q�60    �� TextWrapping$ NoWrap=�6E   $	��Top=�6[    �� 
IsReadOnly . 6s   �� 5M   
   -   5         ��Name$ 
OpenButton��5M      $��열 기��6%   $��Right=�63   $��	0,62,10,0q�6O   $	��Top=�6b   $	��117��6z   $��26��6�   5N      �� 5O   
   -   5         ��Name$ 
SqNumPanel��5O      $��Stretch=�6)   $��25��6G   $��
10,90,10,0q�6S   $	��Top=�6g    �� Orientation$ 
Horizontal=�6   ���	#FFF2F2F26�   �� 5P   
   $
��Left=�6   $��
10,120,0,0q�6/   $��NoWrap=�6C   $>��8시퀀스 번호가 되는 부분을 선택해 주세요��6Y   $	��Top=�6w   $	��650��6�   $��Oblique$�6�   �� 5Q   
   $��저장 경로��6   $
��Left=�6    $��
10,197,0,0q�6;   $	��Top=�6O   �� 5R   
   -   5        $ SavePath��5R      $��23��6$   $��10,228,130,0q�60   $ NoWrap=�6F   $	��Top=�6\    . 6t   �� 5S   
   -   5        $ 
SaveButton��5S      $��저 장��6%   $��Right=�63   $��
0,228,10,0q�6O   $	��Top=�6c   $	��117��6{   $��26��6�   6�   o� 5T   
   $��26��6   $	��Top=�6   $	��792��63   ���	#FFE4E4E4$��0,0,0,1q�6W   .@�5U      m� $��설정��6   .@�5V      m� -   5         m�Name$ 
FFmpegMenu��5V      $��ffmpeg 경로 지정��6/   6E   5W      5X      � 5Z   
   $��
10,0,10,10q�6   $��Bottom=�6#   $��30��6>    � ColumnDefinitions 5[      �� 5\      $
��0.2* �6#   �� 5]      $
��0.2* �6#   �� 5^      $
��0.2* �6#   �� 5_      $
��0.2* �6#   �� 5`      $
��0.2* �6#   �� 5a      $
��0.2* �6#   .+�5c      �� -	   5        $ ConvertButton��5c      $��변환하기��6,   $��Center=�6;   $��0q�6X   $	��100��6c   $��2��6o   6   �� 5d      -
   5        $ CancelButton��5d      $��취 소��6+   $��Center=�69   $��0q�6V   $	��100��6a   $��3��6m   6}   5e      � 5f   
   $��40��6   $��10,160,10,0q�6   $	��Top=�60   $	��774��6H    5g      �� 5h      $
��0.5* �6#   �� 5i      $
��0.5* �6#   �� 5j      $
��0.5* �6#   .+�5l      �� $��0��6   $ 
Horizontal=�6)   .+�5m      �� $��프레임레이트��6   $��Center=�6)   �� 5n      -   5        $ FrameRateField��5n      $	��100��62   $ NoWrap=�6>   $��30��6T   $��Center=�6^   5o      �� 5p      $��1��6   $ 
Horizontal=�6)   .+�5q      �� $��비트 레이트��6   $��Center=�6)   �� 5r      -   5        $ BitRateField��5r      $	��100��60   $��10000��6<   $ NoWrap=�6I   $��Center=�6_   5s      )  #MahApps.Metro.Controls.ToggleSwitch  5t      -   5          Name$ IsShowConsole��5t   $       OnLabel$  Show Console��6;   !   OffLabel$! Hide Console��6R   $��2��6j   $��Center=�6z   "   	IsChecked$" FalseY�6�   $��Center=�6�   $
��Left=�6�   $��Stretch=�6�   $	��160��6	  5u      � 5v   
   -   5        $ Progress��5v      $y�Hidden=�6!   # K� ZIndex$# 1��65   ���	#9C0078D7.+�5w      )  #MahApps.Metro.Controls.ProgressRing  ���	#CCFFFFFF6$   5x      5y      5z      