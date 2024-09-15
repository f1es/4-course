from django.db import models

# Create your models here.
class MusicAlbum(models.Model):
    name = models.CharField(max_length=155)
    author = models.CharField(max_length=155)
    genre = models.CharField(max_length=155)
    year = models.DateField()