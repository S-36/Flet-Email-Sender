import flet as ft
import requests as req
import dotenv as env
import os
def main(page: ft.Page):
    ## Page title
    page.title = "Email sender app"

    ## Centering the content and styling 
    page.vertical_alignment = ft.MainAxisAlignment.CENTER
    page.horizontal_alignment = ft.CrossAxisAlignment.CENTER
    
    ## Inputs fields and buttons for the email sender app
    email_input = ft.TextField(label="Email", width=300, border_color=ft.Colors.WHITE)
    subject_input = ft.TextField(label="Subject", width=300, border_color=ft.Colors.WHITE)
    body_input = ft.TextField(label="Body", width=300, multiline=True, border_color=ft.Colors.WHITE)
    send_button = ft.ElevatedButton(text="Send Email", on_click= lambda e: send_email(email_input, subject_input, body_input))
    
    ## Funtion to handle the button click event
    def send_email(email_input, subject_input, body_input):
        to = email_input.value
        subject = subject_input.value
        body = body_input.value
        
        ## load the environments variables to the http request C# backend
        env.load_dotenv()
        backend_url = os.getenv("BACKEND_URL")

        # Send the email via the backend API
        response = req.post(backend_url, json={
            "to": to,
            "subject": subject,
            "body": body
        })

        if response.status_code == 200 or response.status_code == 201:
            send_button.text = "Email Sent!"
            send_button.update()
        else:
            send_button.text = "Failed to send email."
            send_button.update()
            print(f"Failed to send email: {response.text}")
            

    ## aading the elements to the page and Styling the container and column
    page.add(
        ft.Container(
            ft.Column(
                [
                    email_input,
                    subject_input,
                    body_input,
                    send_button,
                ],
                ## Centering the column content
                alignment=ft.MainAxisAlignment.CENTER,
                horizontal_alignment=ft.CrossAxisAlignment.CENTER
            ),
            ## Container Styling
            bgcolor=ft.Colors.SHADOW,
            height=500,
            width=500,
            alignment=ft.alignment.center,
            border_radius=20
        )   
    )
ft.app(target=main)