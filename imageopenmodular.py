# Import the libraries tkinter, PIL and PIL.Image 
from tkinter import *
from tkinter import filedialog
from tkinter import messagebox
import PIL.Image as im 
import PIL.ImageTk as imtk 
import argparse
import PIL
# Create a parser
parser = argparse.ArgumentParser(description='Process image file.')
parser.add_argument('--img', type=str, help='Path to the image file')
parser.add_argument('--title', type=str, help='Title of the window')
parser.add_argument('--geo', type=str, help='Geometry of the window')
parser.add_argument('--icon', type=str, help='Icon display in window')
# Parse arguments
args = parser.parse_args()

# Create a GUI gui_app 
gui_app = Tk() 
  
# Set the title and geometry to your gui_app 
gui_app.title(args.title) 
gui_app.geometry(args.geo) 
gui_app.iconbitmap(args.icon)

# Create a menu bar
menubar = Menu(gui_app)
gui_app.config(menu=menubar)
def credit():
    messagebox.showinfo("Credits", "Developed by: KIENCORE Develop")
# Create a function to save the image
def save_image():
    # Open save file dialog
    file_path = filedialog.asksaveasfilename(defaultextension=".jpg", initialfile="image.jpg", filetypes=[("JPEG", "*.jpg"), ("PNG", "*.png")])
    if file_path:
        # Save the image
        updated_background_image.save(file_path)

# Add 'Save Image' option to the menu bar
menubar.add_command(label="Lưu Lại Ảnh", command=save_image)
menubar.add_command(label="Credit", command=credit)
# Define Image using PhotoImage function 
background_image = imtk.PhotoImage(file=args.img) 
  
# Create and display the Canvas 
canvas_widget = Canvas(gui_app, width=800, height=500) 
canvas_widget.pack(fill="both", expand=True) 
  
# Displaying the image inside canvas 
canvas_widget.create_image(0, 0, image=background_image, anchor="nw") 
  
# Create a function to resize all the images 
def resize_image(e, updated_background_image): 
    # Resize Image using resize function 
    resized_background_image = updated_background_image.resize((e.width, e.height), PIL.Image.LANCZOS) 
    return resized_background_image 

# Create a function to display other widgets on background 
def display_widgets(): 
    # Write some text on the image 
    canvas_widget.create_text(300, 30, text="", font=('Helvetica', '30', 'bold'), fill='white') 

# Create resize function with argument e 
def image_background(e): 
    global updated_background_image, resized_background_image, new_background_image 

    # Open and identify the image 
    updated_background_image = im.open(args.img) 

    # Call the resize_image function 
    resized_background_image = resize_image(e, updated_background_image) 

    # Define resized image again using PhotoImage function 
    new_background_image = imtk.PhotoImage(resized_background_image) 

    # Display the newly created image in canvas 
    canvas_widget.create_image(0, 0, image=new_background_image, anchor="nw") 
    display_widgets() 

# Get parameters of resizing window and bind python function resizer to screen resize 
gui_app.bind('<Configure>', image_background) 
  
# Make the infinite loop for displaying the gui_app 
gui_app.mainloop()
