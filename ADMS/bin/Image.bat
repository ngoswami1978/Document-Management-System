REM Batch pgm starts here

EXPAND C:\Program Files\ADMS\KODAKIMG.EX_ C:\Program Files\ADMS\KODAKIMG.EXE
EXPAND C:\Program Files\ADMS\KODAKPRV.EX_ C:\Program Files\ADMS\KODAKPRV.EXE
EXPAND C:\Program Files\ADMS\IMGADMIN.OC_ C:\Program Files\ADMS\IMGADMIN.OCX
EXPAND C:\Program Files\ADMS\IMGEDIT.OC_ C:\Program Files\ADMS\IMGEDIT.OCX
EXPAND C:\Program Files\ADMS\IMGSCAN.OC_ C:\Program Files\ADMS\IMGSCAN.OCX
EXPAND C:\Program Files\ADMS\IMGTHUMB.OC_ C:\Program Files\ADMS\IMGTHUMB.OCX
EXPAND C:\Program Files\ADMS\OCKODAK.DL_ C:\Program Files\ADMS\OCKODAK.DLL
EXPAND C:\Program Files\ADMS\IMGCMN.DL_ C:\Program Files\ADMS\IMGCMN.DLL
EXPAND C:\Program Files\ADMS\OIENG400.DL_ C:\Program Files\ADMS\OIENG400.DLL
EXPAND C:\Program Files\ADMS\OIPRT400.DL_ C:\Program Files\ADMS\OIPRT400.DLL
EXPAND C:\Program Files\ADMS\OISLB400.DL_ C:\Program Files\ADMS\OISLB400.DLL
EXPAND C:\Program Files\ADMS\OISSQ400.DL_ C:\Program Files\ADMS\OISSQ400.DLL
EXPAND C:\Program Files\ADMS\OIUI400.DL_ C:\Program Files\ADMS\OIUI400.DLL
EXPAND C:\Program Files\ADMS\OITWA400.DL_ C:\Program Files\ADMS\OITWA400.DLL

regsvr32 "C:\Program Files\ADMS\IMGADMIN.OCX" 
regsvr32 "C:\Program Files\ADMS\IMGTHUMB.OCX" 
regsvr32 "C:\Program Files\ADMS\IMGSCAN.OCX" 
regsvr32 "C:\Program Files\ADMS\IMGEDIT.OCX" 



REM Batch pgm ends here
