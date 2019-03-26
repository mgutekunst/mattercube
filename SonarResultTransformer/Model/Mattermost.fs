module Model.Mattermost

type Field = {
    Short: bool;
    Title: string;
    Value: string;
}

type Attachment = {
    Title: string;
    Text: string;
    Fields: Field[]
}

type MattermostNotification = {
    Channel: string;
    Username: string;
    Icon_Url: string;
    Text: string;
    Attachments: Attachment[];
}
