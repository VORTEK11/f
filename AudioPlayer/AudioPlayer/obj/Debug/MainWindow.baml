   M S B A M L   `   `   `  ����  AudioPlayer    AudioPlayer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Audio Player��5   	   $	��450��6   $	��800��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Audio Player��6   $��24(�6(   $
��Bold"�66   $��Center=�6H   �� 5   
   -   5        $��Выбрать папку��5      $��10q�6)   $��1��65   $��Center=�6B   6_   r� 5   
   -   5         r�Name$ mediaElement��5      $��2��6-    r� LoadedBehavior$ Manual=�6:   6y   �� 5   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5      �� -   5        $	����5      $��Segoe MDL2 Assets)�6(   $��16(�6G   6U   �� 5      -   5         ��Name$ playPauseButton��5      $	����6.   $��Segoe MDL2 Assets)�6A   $��24(�6`   6n   �� 5       -   5        $	����5       $��Segoe MDL2 Assets)�6(   $��16(�6G   6U   �� 5#      -   5        $ repeatButton��5#      $	����6+   $��Segoe MDL2 Assets)�6>   $��16(�6]   6k   �� 5&      -   5        $ shuffleButton��5&      $	����6,   $��Segoe MDL2 Assets)�6?   $��16(�6^   6l   5'      �� 5*   
   -   5         ��Name$ positionSlider��5*      $��4��6)   $��10q�66   6B   �� 5-   
   -	   5         ��Name$ timeInfoText��5-      $��4��6*   $��Right=�67   $��0,0,10,0q�6S   5.      5/      