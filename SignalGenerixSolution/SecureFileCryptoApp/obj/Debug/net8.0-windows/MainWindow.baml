   M S B A M L   `   `   `  ����  SecureFileCryptoApp$    SecureFileCryptoApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Secure File Encryptor��5   	   $	��350��6'   $	��525��64   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5         ��Name$ FilePathTextBox��5      $	��400��6/    �� 
IsReadOnly$
 True��6;   $��0,0,10,0q�6M   �� 5      -   5         ��Name$ BrowseButton��5      $��Browse��6+   $��80��6<   6G   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� $��	Password:��6   $	��100��6(   G� 5      -   5         G�Name$ PasswordBox��5      $	��290��6/   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5        $ EncryptButton��5      $��Encrypt��6,   $	��100��6>   $��0,0,10,0q�6f   �� 5      -   5        $ DecryptButton��5      $��Decrypt��6,   $	��100��6>   6J   5      �� 5   
   -   5         ��Name$ StatusTextBlock��5      $��3��6-   $
��Wrap=�6:   $��0,0,0,10q�6N   �� 5   
   -   5        $ 
LogTextBox��5      $��4��6&   $
 True��63   " �� VerticalScrollBarVisibility$
 Auto=�6E   $	 �� HorizontalScrollBarVisibility$
	 Auto=�6h   5       5!      