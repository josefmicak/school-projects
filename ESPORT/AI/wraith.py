import pygame
import numpy as np
from my_object import My_Object


class Wraith(My_Object):
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
        if self.type == 1:
            self.img = pygame.image.load('enemy_wraith_1/Idle/Wraith_01_Idle Blinking_000.png')
        if self.type == 2:
            self.img = pygame.image.load('enemy_wraith_2/Idle/Wraith_02_Idle Blinking_000.png')
        if self.type == 3:
            self.img = pygame.image.load('enemy_wraith_3/Idle/Wraith_03_Idle Blinking_000.png')

    def show(self, game_display):
            game_display.blit(self.img, (self.x, self.y))

    def get_height(self):
        return self.img.get_height()

    def get_width(self):
        return self.img.get_width()

    def update_image(self):
        if self.action == 'Walking':
            if self.image_id < 10:
                path = 'enemy_wraith_' + str(self.type) + '/Walking/Wraith_0' + str(self.type) + '_Moving Forward_00' + str(self.image_id) + '.png'
            else:
                path = 'enemy_wraith_' + str(self.type) + '/Walking/Wraith_0' + str(self.type) + '_Moving Forward_0' + str(self.image_id) + '.png'
        elif self.action == 'Walking_left':
            if self.image_id < 10:
                path = 'enemy_wraith_' + str(self.type) + '/Walking_left/Wraith_0' + str(self.type) + '_Moving Forward_00' + str(self.image_id) + '.png'
            else:
                path = 'enemy_wraith_' + str(self.type) + '/Walking_left/Wraith_0' + str(self.type) + '_Moving Forward_0' + str(self.image_id) + '.png'
        elif self.action == 'Attacking':
            if self.image_id < 10:
                path = 'enemy_wraith_' + str(self.type) + '/Attacking/Wraith_0' + str(self.type) + '_Attack_00' + str(self.image_id) + '.png'
            else:
                path = 'enemy_wraith_' + str(self.type) + '/Attacking/Wraith_0' + str(self.type) + '_Attack_0' + str(self.image_id) + '.png'
        elif self.action == 'Attacking_left':
            if self.image_id < 10:
                path = 'enemy_wraith_' + str(self.type) + '/Attacking_left/Wraith_0' + str(self.type) + '_Attack_00' + str(self.image_id) + '.png'
            else:
                path = 'enemy_wraith_' + str(self.type) + '/Attacking_left/Wraith_0' + str(self.type) + '_Attack_0' + str(self.image_id) + '.png'
        elif self.action == 'Hurt':
            if self.image_id < 10:
                path = 'enemy_wraith_' + str(self.type) + '/Hurt/Wraith_0' + str(self.type) + '_Hurt_00' + str(self.image_id) + '.png'
            else:
                path = 'enemy_wraith_' + str(self.type) + '/Hurt/Wraith_0' + str(self.type) + '_Hurt_0' + str(self.image_id) + '.png'
        elif self.action == 'Dying':
            if self.image_id < 10:
                path = 'enemy_wraith_' + str(self.type) + '/Dying/Wraith_0' + str(self.type) + '_Dying_00' + str(self.image_id) + '.png'
            else:
                path = 'enemy_wraith_' + str(self.type) + '/Dying/Wraith_0' + str(self.type) + '_Dying_0' + str(self.image_id) + '.png'
        self.img = pygame.image.load(path)
