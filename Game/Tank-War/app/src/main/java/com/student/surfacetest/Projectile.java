package com.student.surfacetest;


public class Projectile extends Unit {

    public Projectile(int owner, int x, int y, int direction, int pixelsPerBlock) {
        this.x = x;
        this.y = y;
        this.direction = direction;
        this.owner = owner;
        speed = (int)(pixelsPerBlock / 10 * 2.5);
        isMoving = true;
    }

}
