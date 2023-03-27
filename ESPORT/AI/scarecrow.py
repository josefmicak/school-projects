import pygame
import numpy as np
from my_object import My_Object


class Scarecrow(My_Object):
    def __init__(self, screen_width, screen_height, left_offset, right_offset, down_offset, direction, action, image_id, health, type, x=None,y=None):
        super().__init__(screen_width, screen_height, left_offset, right_offset, down_offset, direction, action, image_id, health, type, x, y)
        self.x = x
        self.y = y
        self.type = type
        self.left_offset = left_offset
        self.right_offset = right_offset
        self.down_offset = down_offset
        self.action = action
        self.image_id = image_id
        self.direction = direction
        self.health = health
        self.img = pygame.image.load('scarecrow/Idle/std_0.png')

    def show(self, game_display):
            game_display.blit(self.img, (self.x, self.y))

    def get_height(self):
        return self.img.get_height()

    def get_width(self):
        return self.img.get_width()

    def update_image(self):
        if self.action == 'Walking':
            path = 'scarecrow/Walking/walk_' + str(self.image_id) + '.png'
        elif self.action == 'Walking_left':
            path = 'scarecrow/Walking_left/walk_' + str(self.image_id) + '.png'
        if self.action == 'Attacking':
            path = 'scarecrow/Attacking/atk_' + str(self.image_id) + '.png'
        elif self.action == 'Attacking_left':
            path = 'scarecrow/Attacking_left/atk_' + str(self.image_id) + '.png'
        elif self.action == 'Rotating':
            path = 'scarecrow/Rotating/jifei_' + str(self.image_id) + '.png'
        self.img = pygame.image.load(path)