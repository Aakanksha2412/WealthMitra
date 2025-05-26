from tkinter import *

class IMS:
    def __init__(self, root):
        self.root = root
        self.root.geometry("1350x700+0+0")
        self.root.title("Inventory Management System | Developed by Aakanksha")

        # Title Label using pack()
        self.icon_title=PhotoImage(file="images/logo1.png")
        title = Label(self.root, text="Inventory Management System",image=self.icon_title,compound=LEFT,font=("sans-serif", 40, "bold"), bg="light blue", fg="white",anchor="w",padx=20)
        title.pack(fill=X)

        # button_logout
        btn_logout = Button(self.root, text="Logout", font=("sans-serif", 15, "bold"), bg="yellow", cursor="hand1")
        btn_logout.place(x=1150, y=10, height=50, width=150)


#if __name__ == "__main__":
root = Tk()
obj = IMS(root)
root.mainloop()
