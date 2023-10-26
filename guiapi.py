import os
import shutil
import subprocess
from tkinter import Tk, simpledialog, messagebox
from tkinter.filedialog import askopenfilename
import tkinter as tk
from tkinter import *
from PIL import Image, ImageTk 
import json
os.makedirs('cache/input', exist_ok=True)
os.makedirs('cache/output', exist_ok=True)
def writefile():
    data = {
            "gx": 800,
            "gy": 600,
            "ix": 800,
            "iy": 600
        }
    with open('setting.json', 'w') as f:
        json.dump(data, f)  
def checkfile():
    if not os.path.exists('setting.json'):
        messagebox.showerror("Cảnh Báo!", "Không tìm thấy file cài đặt, nhấn OK để tải lại file cài đặt!")
        writefile()
def check_and_write(gx, gy, ix, iy):
    try:
            gx_int = int(gx)
            gy_int = int(gy)
            ix_int = int(ix)
            iy_int = int(iy)
    except ValueError:
        messagebox.showerror("Cảnh Báo!", "Tham số màn hình bị sai, nhấn OK để tải lại file cài đặt!")
        writefile()
    
def setting():
    str1 = Tk()
    with open('setting.json', 'r') as f:
        data = json.load(f)
        gx = data["gx"]
        gy = data["gy"]
        ix = data["ix"]
        iy = data["iy"]
    str1.title("Cài Đặt")
    str1.iconbitmap("asset/icon.ico")
    str1.geometry(str(gx)+"x"+str(gy))
    l1 = Label(str1,text="- Nhập Chiều Ngang Của Cửa Sổ (px):")
    l1.grid(row=0,column=0)
    t1 = Entry(str1)
    t1.insert(0, gx)
    t1.grid(row=0,column=1)
    
    l2 = Label(str1,text="- Nhập Chiều Dọc Của Cửa Sổ (px):")
    l2.grid(row=1,column=0)
    t2 = Entry(str1)
    t2.insert(0, gy)
    t2.grid(row=1,column=1)
    
    l1i = Label(str1,text="- Nhập Chiều Ngang Của Cửa Sổ Xem Ảnh (px):")
    l1i.grid(row=2,column=0)
    t1i = Entry(str1)
    t1i.insert(0, ix)
    t1i.grid(row=2,column=1)
    
    l2i = Label(str1,text="- Nhập Chiều Dọc Của Cửa Sổ Xem Ảnh (px):")
    l2i.grid(row=3,column=0)
    t2i = Entry(str1)
    t2i.insert(0, iy)
    t2i.grid(row=3,column=1)
    def save():
        gxs = t1.get()
        gys = t2.get()
        ixs = t1i.get()
        iys = t2i.get()
        data = {
            "gx": gxs,
            "gy": gys,
            "ix": ixs,
            "iy": iys
        }
        with open('setting.json', 'w') as f: 
            json.dump(data, f) 
    def run():
        gxc = t1.get()
        gyc = t2.get()
        ixc = t1i.get()
        iyc = t2i.get()
        try:
            gx_int = int(gxc)
            gy_int = int(gyc)
            ix_int = int(ixc)
            iy_int = int(iyc)
            save()
            messagebox.showinfo("Thông Báo!", "Tham Số Đã Lưu Thành Công!")
        except ValueError:
            messagebox.showerror("Cảnh Báo!", "Tham Số Sai Vui Lòng Nhập Lại!")
    b1 = Button(str1,text="Lưu Cài Đặt",command=run).grid(column=1,row=100)

def credit():
    messagebox.showinfo("Credits", "Developed by: KIENCORE Develop, Wu Huikai")
def main(file1, file2, output_file_name):
    file1_name = os.path.basename(file1)
    file2_name = os.path.basename(file2)

    shutil.copy(file1, f"cache/input/{file1_name}")
    shutil.copy(file2, f"cache/input/{file2_name}")
    output_file_name += ".jpg"
    # Đường dẫn tới thư mục PythonEnvironment
    python_env_path = os.path.join(os.getcwd(), 'PythonEnvironment')

    # Đường dẫn tới file python.exe trong thư mục PythonEnvironment
    python_exe_path = os.path.join(python_env_path, 'python.exe')
    
    # Đường dẫn tới file main.py
    main_py_path = os.path.join(os.getcwd(), 'main.py')
    
    # Command-line arguments for main.py
    args = f'--src cache/input/{file1_name} --dst cache/input/{file2_name} --out cache/output/{output_file_name} --correct_color --no_debug_window'
    
    # Tạo câu lệnh để chạy file main.py bằng python.exe
    command = f'"{python_exe_path}" "{main_py_path}" {args}'
    
    # In câu lệnh ra console
    print(command)
    
    # Chạy câu lệnh
    process = subprocess.Popen(command, shell=True, stdout=subprocess.PIPE)
    process.wait()
    filepath = "cache/output/"
    global full_path
    full_path = filepath + output_file_name
checkfile()
with open('setting.json', 'r') as f:
    data = json.load(f)
    gx = data["gx"]
    gy = data["gy"]
    ix = data["ix"]
    iy = data["iy"]
check_and_write(gx,gy,ix,iy)
win = Tk()
win.geometry(str(gx)+"x"+str(gy))
win.iconbitmap("asset/icon.ico")
win.title("Phần Mềm Ghép Khuôn Mặt")

menu = tk.Menu(win)
win.config(menu=menu)

def open_file1():
    global file1_path
    file1_path = askopenfilename(title="Chọn File Lấy Mặt")

def open_file2():
    global file2_path
    file2_path = askopenfilename(title="Chọn File Làm Mục Tiêu")

menu.add_command(label='Chọn File Lấy Mặt', command=open_file1)
menu.add_command(label='Chọn File Làm Mục Tiêu', command=open_file2)
menu.add_command(label='Cài Đặt', command=setting)
menu.add_command(label='Credit', command=credit)
menu.add_command(label='Thoát', command=quit)
l1 = tk.Label(win,text="Sau Khi Nhập File Xong Thì Nhấn Vào Nút Này:").pack()

def execute_main():
    try:
        output_file_name = simpledialog.askstring("Tên file đầu ra", "Nhập tên file đầu ra (Chỉ Nhập Tên File, Không cần nhập đuôi):")
        main(file1_path, file2_path, output_file_name)
    except NameError:
        messagebox.showinfo("Cảnh Báo!", "Thiếu File Vui Lòng Bổ Sung!")
    else:
        print(full_path)
        # Đường dẫn tới thư mục PythonEnvironment
        python_env_path = os.path.join(os.getcwd(), 'PythonEnvironment')
        
        # Đường dẫn tới file python.exe trong thư mục PythonEnvironment
        python_exe_path = os.path.join(python_env_path, 'python.exe')
        
        # Đường dẫn tới file imageopenmodular.py
        imageopenmodular_py_path = os.path.join(os.getcwd(), 'imageopenmodular.py')
        
        # Command-line arguments for imageopenmodular.py
        args = f'--img {full_path} --geo {str(ix)+"x"+str(iy)} --title "File Ảnh Đầu Ra" --icon asset/icon.ico'
        
        # Tạo câu lệnh để chạy file imageopenmodular.py bằng python.exe
        command = f'"{python_exe_path}" "{imageopenmodular_py_path}" {args}'
        print(command)
        
        # Chạy câu lệnh
        process = subprocess.Popen(command, shell=True, stdout=subprocess.PIPE)
        process.wait()
b1 = tk.Button(win, text ="Thực Hiện Chuyển Đổi", command=execute_main).pack()

win.mainloop()
